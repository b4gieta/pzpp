using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pzpp.Data;
using pzpp.Models;
using System.Diagnostics;

namespace pzpp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var threads = _context.Threads
                .Include(t => t.Posts)
                .OrderByDescending(t => t.Posts.Any() ? t.Posts.Max(p => p.CreatedAt) : t.CreatedAt)
                .ToList();

            return View(threads);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
