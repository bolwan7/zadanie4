using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zadanie4.Models;
using System.Threading.Tasks;

namespace zadanie4.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            return View(user);
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
