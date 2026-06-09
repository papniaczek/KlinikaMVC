using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KlinikaMVC.Data;
using KlinikaMVC.Models;

namespace KlinikaMVC.Controllers
{
    public class PacjenciController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacjenciController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pacjenci
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pacjenci.Include(p => p.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pacjenci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacjent = await _context.Pacjenci
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacjent == null)
            {
                return NotFound();
            }

            return View(pacjent);
        }

        // GET: Pacjenci/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Pacjenci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdentityUserId,Imie,Nazwisko,Dlug")] Pacjent pacjent)
        {
            ModelState.Remove("IdentityUser");
            ModelState.Remove("Wizyty");
            ModelState.Remove("PacjenciGrupy");
            ModelState.Remove("PrzypisaniaUzaleznien");
            ModelState.Remove("UdostepnieniaZadan");
            
            if (ModelState.IsValid)
            {
                _context.Add(pacjent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", pacjent.IdentityUserId);
            return View(pacjent);
        }

        // GET: Pacjenci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacjent = await _context.Pacjenci.FindAsync(id);
            if (pacjent == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", pacjent.IdentityUserId);
            return View(pacjent);
        }

        // POST: Pacjenci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdentityUserId,Imie,Nazwisko,Dlug")] Pacjent pacjent)
        {
            if (id != pacjent.Id)
            {
                return NotFound();
            }

            ModelState.Remove("IdentityUser");
            ModelState.Remove("Wizyty");
            ModelState.Remove("PacjenciGrupy");
            ModelState.Remove("PrzypisaniaUzaleznien");
            ModelState.Remove("UdostepnieniaZadan");
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacjent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacjentExists(pacjent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", pacjent.IdentityUserId);
            return View(pacjent);
        }

        // GET: Pacjenci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacjent = await _context.Pacjenci
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacjent == null)
            {
                return NotFound();
            }

            return View(pacjent);
        }

        // POST: Pacjenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacjent = await _context.Pacjenci.FindAsync(id);
            if (pacjent != null)
            {
                _context.Pacjenci.Remove(pacjent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacjentExists(int id)
        {
            return _context.Pacjenci.Any(e => e.Id == id);
        }
    }
}
