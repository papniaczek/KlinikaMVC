using Microsoft.AspNetCore.Mvc;
using KlinikaMVC.Data;
using KlinikaMVC.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace KlinikaMVC.Controllers
{
    public class PrezentacjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrezentacjaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GenerujDane()
        {
            _context.Database.SetCommandTimeout(300);

            var terapeuta = _context.Terapeuci.FirstOrDefault();
            if (terapeuta == null)
            {
                var fakeUser = new IdentityUser 
                { 
                    UserName = "drhouse@klinika.pl", 
                    Email = "drhouse@klinika.pl",
                    NormalizedEmail = "DRHOUSE@KLINIKA.PL",
                    NormalizedUserName = "DRHOUSE@KLINIKA.PL"
                };
                _context.Users.Add(fakeUser);
                _context.SaveChanges();

                terapeuta = new Terapeuta 
                { 
                    Imie = "Dr House", 
                    Specjalizacja = "Terapia szokowa",
                    IdentityUserId = fakeUser.Id
                };
                _context.Terapeuci.Add(terapeuta);
                _context.SaveChanges();
            }

            var faker = new Faker<Zadanie>("pl")
                .RuleFor(z => z.Id, f => 0) 
                .RuleFor(z => z.Tytul, f => 
                {
                    var tekst = f.Lorem.Sentance();
                    return tekst.Length > 30 ? tekst.Substring(0, 30) : tekst;
                })
                .RuleFor(z => z.TerapeutaId, f => terapeuta.Id);

            var fejkoweZadania = faker.Generate(20000).ToList(); 

            _context.ChangeTracker.AutoDetectChangesEnabled = false;

            int rozmiarPaczki = 5000;
            for (int i = 0; i < fejkoweZadania.Count; i += rozmiarPaczki)
            {
                var paczka = fejkoweZadania.Skip(i).Take(rozmiarPaczki).ToList();
                _context.Zadania.AddRange(paczka);
                
                _context.SaveChanges();
                _context.ChangeTracker.Clear(); 
            }

            _context.ChangeTracker.AutoDetectChangesEnabled = true;

            return Content("Gites");
        }

        public IActionResult Dluznicy()
        {
            _context.Database.SetCommandTimeout(300);

            // Odpalamy poprawioną procedurę
            var raport = _context.Pacjenci
                .FromSqlRaw("EXEC sp_RaportDlugow")
                .ToList();

            // Zmieniamy z Json(raport) na View(raport) -> to stworzy nam prawdziwą stronę www
            return View(raport);
        }
    }
}