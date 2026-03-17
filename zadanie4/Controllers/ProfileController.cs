using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zadanie4.Models;
using zadanie4.Data;
using zadanie4.ViewModels;
using System.Threading.Tasks;
using System.Linq;

namespace zadanie4.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;

        public ProfileController(UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var profiles = _context.Profile
                .Where(p => p.ApplicationUserId == user.Id)
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            var vm = new ProfileViewModel
            {
                User = user,
                Profiles = profiles
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDisplayName(string displayName)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            user.DisplayName = displayName ?? string.Empty;
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index");
        }
    }
}
