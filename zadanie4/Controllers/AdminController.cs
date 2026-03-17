using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zadanie4.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
                .Include(p => p.ApplicationUser)
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            return View(history);
        }

        public IActionResult Points()
        {
            var pytania = _context.Pytania
                .Include(p => p.Odpowiedzi)
                .OrderBy(p => p.Id)
                .ToList();

            return View(pytania);
        }
    }
}
