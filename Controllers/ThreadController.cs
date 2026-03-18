using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pzpp.Data;
using pzpp.Models;

public class ThreadController : Controller
{
    private readonly AppDbContext _context;

    public ThreadController(AppDbContext context)
    {
        _context = context;
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
        var user = _context.Users.FirstOrDefault();

        if (user == null)
        {
            user = new User { Id = 1 };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        var thread = new pzpp.Models.Thread
        {
            Title = title,
            CreatedAt = DateTime.UtcNow,
            CreatedByUserId = user.Id
        };

        _context.Threads.Add(thread);
        _context.SaveChanges();

        var post = new Post
        {
            ThreadId = thread.Id,
            Content = content,
            CreatedAt = DateTime.UtcNow,
            UserId = user.Id
        };

        _context.Posts.Add(post);
        _context.SaveChanges();

        return RedirectToAction("Index", new { id = thread.Id });
    }
}