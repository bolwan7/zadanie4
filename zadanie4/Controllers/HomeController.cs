using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zadanie4.Data;
using zadanie4.Models;    
using zadanie4.ViewModels;

namespace zadanie4.Controllers
{
    public class QuizController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public QuizController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

       
        public IActionResult Index()
        {
            var pytania = _context.Pytania
                .Include(p => p.Odpowiedzi)
                .OrderBy(p => p.Id)
                .ToList();

            var vm = new QuizViewModel { Pytania = pytania };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(QuizViewModel model)
        {
            if (model.WybraneOdpowiedzi == null || !model.WybraneOdpowiedzi.Any())
                return RedirectToAction("Index");

            var user = await _userManager.GetUserAsync(User);

            var profil = new ProfilUzytkownika
            {
                Imie = user?.DisplayName ?? user?.UserName ?? "Anonim",
                ApplicationUserId = user?.Id
            };


          
            var ids = model.WybraneOdpowiedzi.Values.ToList();
            var odpowiedzi = _context.Odpowiedzi
                .Where(o => ids.Contains(o.Id))
                .ToList();

            foreach (var odp in odpowiedzi)
            {
                profil.Cialo += odp.PunktyCialo;
                profil.Umysl += odp.PunktyUmysl;
                profil.Relacje += odp.PunktyRelacje;
                profil.Praca += odp.PunktyPraca;
                profil.Duchowosc += odp.PunktyDuchowosc;
            }

            _context.Profile.Add(profil);
            await _context.SaveChangesAsync();

            return RedirectToAction("Result", new { id = profil.Id });
        }

       
        public IActionResult Result(int id)
        {
            var profil = _context.Profile.FirstOrDefault(p => p.Id == id);

            if (profil == null)
                return NotFound();

            return View(profil);
        }
    }
}