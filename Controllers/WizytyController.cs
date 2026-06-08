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
    public class WizytyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WizytyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wizyty
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Wizyty.Include(w => w.Pacjent).Include(w => w.Status).Include(w => w.Terapeuta);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Wizyty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wizyta = await _context.Wizyty
                .Include(w => w.Pacjent)
                .Include(w => w.Status)
                .Include(w => w.Terapeuta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wizyta == null)
            {
                return NotFound();
            }

            return View(wizyta);
        }

        // GET: Wizyty/Create
        public IActionResult Create()
        {
            ViewData["PacjentId"] = new SelectList(_context.Pacjenci, "Id", "Id");
            ViewData["StatusId"] = new SelectList(_context.StatusyWizyt, "Id", "Id");
            ViewData["TerapeutaId"] = new SelectList(_context.Terapeuci, "Id", "Id");
            return View();
        }

        // POST: Wizyty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataWizyty,PacjentId,TerapeutaId,StatusId")] Wizyta wizyta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wizyta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacjentId"] = new SelectList(_context.Pacjenci, "Id", "Id", wizyta.PacjentId);
            ViewData["StatusId"] = new SelectList(_context.StatusyWizyt, "Id", "Id", wizyta.StatusId);
            ViewData["TerapeutaId"] = new SelectList(_context.Terapeuci, "Id", "Id", wizyta.TerapeutaId);
            return View(wizyta);
        }

        // GET: Wizyty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wizyta = await _context.Wizyty.FindAsync(id);
            if (wizyta == null)
            {
                return NotFound();
            }
            ViewData["PacjentId"] = new SelectList(_context.Pacjenci, "Id", "Id", wizyta.PacjentId);
            ViewData["StatusId"] = new SelectList(_context.StatusyWizyt, "Id", "Id", wizyta.StatusId);
            ViewData["TerapeutaId"] = new SelectList(_context.Terapeuci, "Id", "Id", wizyta.TerapeutaId);
            return View(wizyta);
        }

        // POST: Wizyty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataWizyty,PacjentId,TerapeutaId,StatusId")] Wizyta wizyta)
        {
            if (id != wizyta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wizyta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WizytaExists(wizyta.Id))
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
            ViewData["PacjentId"] = new SelectList(_context.Pacjenci, "Id", "Id", wizyta.PacjentId);
            ViewData["StatusId"] = new SelectList(_context.StatusyWizyt, "Id", "Id", wizyta.StatusId);
            ViewData["TerapeutaId"] = new SelectList(_context.Terapeuci, "Id", "Id", wizyta.TerapeutaId);
            return View(wizyta);
        }

        // GET: Wizyty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wizyta = await _context.Wizyty
                .Include(w => w.Pacjent)
                .Include(w => w.Status)
                .Include(w => w.Terapeuta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wizyta == null)
            {
                return NotFound();
            }

            return View(wizyta);
        }

        // POST: Wizyty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wizyta = await _context.Wizyty.FindAsync(id);
            if (wizyta != null)
            {
                _context.Wizyty.Remove(wizyta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WizytaExists(int id)
        {
            return _context.Wizyty.Any(e => e.Id == id);
        }
    }
}
