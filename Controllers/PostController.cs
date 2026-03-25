using Microsoft.AspNetCore.Mvc;
using pzpp.Data;
using pzpp.Models;
using System.Threading;

public class PostController : Controller
{
    private readonly AppDbContext _context;

    public PostController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Create(int threadId, string content)
    {

        if (string.IsNullOrWhiteSpace(content))
            return RedirectToAction("Index", "Thread", new { id = threadId });

        var username = HttpContext.Session.GetString("user");
        var user = _context.Users.Where(u => u.Login == username).FirstOrDefault();

        var post = new Post
        {
            ThreadId = threadId,
            Content = content,
            CreatedAt = DateTime.UtcNow,
            UserId = user.Id
        };

        _context.Posts.Add(post);
        _context.SaveChanges();

        return Redirect($"/Thread?id={threadId}");
    }
}