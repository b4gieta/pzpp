using Microsoft.AspNetCore.Mvc;
using pzpp.Data;
using pzpp.Models;

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

        var post = new Post
        {
            ThreadId = threadId,
            Content = content,
            CreatedAt = DateTime.UtcNow,
            UserId = 1
        };

        _context.Posts.Add(post);
        _context.SaveChanges();

        return RedirectToAction("Index", "Thread", new { id = threadId });
    }
}