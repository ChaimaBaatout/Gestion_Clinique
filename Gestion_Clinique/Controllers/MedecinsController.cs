using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion_Clinique.Data;

namespace Gestion_Clinique.Models
{
    public class MedecinsController : Controller
    {
        private readonly Gestion_CliniqueContext _context;

        public MedecinsController(Gestion_CliniqueContext context)
        {
            _context = context;
        }

        // GET: Medecins
        public async Task<IActionResult> Index()
        {
            var gestion_CliniqueContext = _context.Medecin.Include(m => m.DateDeTravail).Include(m => m.Specialite);
            return View(await gestion_CliniqueContext.ToListAsync());
        }

        // GET: Medecins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medecin = await _context.Medecin
                .Include(m => m.DateDeTravail)
                .Include(m => m.Specialite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medecin == null)
            {
                return NotFound();
            }

            return View(medecin);
        }

        // GET: Medecins/Create
        public IActionResult Create()
        {
            ViewData["DateDeTravailId"] = new SelectList(_context.Set<DateDeTravail>(), "ID", "ID");
            ViewData["SpecialiteId"] = new SelectList(_context.Set<Specialite>(), "Id", "Id");
            return View();
        }

        // POST: Medecins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecialiteId,DateDeTravailId,Prix_visite,Activate,CIN,Id,Nom,Prenom,Email,MotDePasse")] Medecin medecin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medecin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DateDeTravailId"] = new SelectList(_context.Set<DateDeTravail>(), "ID", "ID", medecin.DateDeTravailId);
            ViewData["SpecialiteId"] = new SelectList(_context.Set<Specialite>(), "Id", "Id", medecin.SpecialiteId);
            return View(medecin);
        }

        // GET: Medecins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medecin = await _context.Medecin.FindAsync(id);
            if (medecin == null)
            {
                return NotFound();
            }
            ViewData["DateDeTravailId"] = new SelectList(_context.Set<DateDeTravail>(), "ID", "ID", medecin.DateDeTravailId);
            ViewData["SpecialiteId"] = new SelectList(_context.Set<Specialite>(), "Id", "Id", medecin.SpecialiteId);
            return View(medecin);
        }

        // POST: Medecins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecialiteId,DateDeTravailId,Prix_visite,Activate,CIN,Id,Nom,Prenom,Email,MotDePasse")] Medecin medecin)
        {
            if (id != medecin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medecin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedecinExists(medecin.Id))
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
            ViewData["DateDeTravailId"] = new SelectList(_context.Set<DateDeTravail>(), "ID", "ID", medecin.DateDeTravailId);
            ViewData["SpecialiteId"] = new SelectList(_context.Set<Specialite>(), "Id", "Id", medecin.SpecialiteId);
            return View(medecin);
        }

        // GET: Medecins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medecin = await _context.Medecin
                .Include(m => m.DateDeTravail)
                .Include(m => m.Specialite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medecin == null)
            {
                return NotFound();
            }

            return View(medecin);
        }

        // POST: Medecins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medecin = await _context.Medecin.FindAsync(id);
            _context.Medecin.Remove(medecin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedecinExists(int id)
        {
            return _context.Medecin.Any(e => e.Id == id);
        }
    }
}
