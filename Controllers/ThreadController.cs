using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pzpp.Data;
using pzpp.Models;
using pzpp.Services;

public class ThreadController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserService _userService;

    public ThreadController(AppDbContext context, UserService userService)
    {
        _context = context;
        _userService = userService;
    }

    public IActionResult Index(int? id)
    {
        if (id == null)
        {
            // brak id - lista wątków
            var threads = _context.Threads.ToList();
            return View("List", threads);
        }

        // id podane - wyświetl wątek
        var thread = _context.Threads
            .Include(t => t.Posts)
            .FirstOrDefault(t => t.Id == id.Value);

        if (thread == null) return NotFound();

        return View(thread);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateWithPost(string title, string content)
    {
        var username = HttpContext.Session.GetString("user");
        if (username == null) return Unauthorized();

        // user z DB (TEN jest potrzebny do ID)
        var dbUser = _context.Users.FirstOrDefault(u => u.Login == username);
        if (dbUser == null) return BadRequest("User nie istnieje w DB");

        var thread = new pzpp.Models.Thread
        {
            Title = title,
            CreatedAt = DateTime.UtcNow,
            CreatedByUserId = dbUser.Id
        };

        _context.Threads.Add(thread);
        _context.SaveChanges();

        var post = new Post
        {
            ThreadId = thread.Id,
            Content = content,
            CreatedAt = DateTime.UtcNow,
            UserId = dbUser.Id
        };

        _context.Posts.Add(post);
        _context.SaveChanges();

        return Redirect($"/Thread?id={thread.Id}");
    }
}