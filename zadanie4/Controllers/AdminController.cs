using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zadanie4.Data;
using System.Linq;

namespace zadanie4.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var history = _context.Profile
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            return View(history);
        }
    }
}
