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
    public class RendezVousController : Controller
    {
        private readonly Gestion_CliniqueContext _context;

        public RendezVousController(Gestion_CliniqueContext context)
        {
            _context = context;
        }

        // GET: RendezVous
        public async Task<IActionResult> Index()
        {
            var gestion_CliniqueContext = _context.RendezVous.Include(r => r.Medecin).Include(r => r.Patient);
            return View(await gestion_CliniqueContext.ToListAsync());
        }

        // GET: RendezVous/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezVous = await _context.RendezVous
                .Include(r => r.Medecin)
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rendezVous == null)
            {
                return NotFound();
            }

            return View(rendezVous);
        }

        // GET: RendezVous/Create
        public IActionResult Create()
        {
            ViewData["MedecinId"] = new SelectList(_context.Medecin, "Id", "Nom");
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Nom");
            return View();
        }

        // POST: RendezVous/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedecinId,PatientId,Id,Date,Heure,Valider")] RendezVous rendezVous)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rendezVous);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedecinId"] = new SelectList(_context.Medecin, "Id", "Nom", rendezVous.MedecinId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Nom", rendezVous.PatientId);
            return View(rendezVous);
        }

        // GET: RendezVous/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezVous = await _context.RendezVous.FindAsync(id);
            if (rendezVous == null)
            {
                return NotFound();
            }
            ViewData["MedecinId"] = new SelectList(_context.Medecin, "Id", "Nom", rendezVous.MedecinId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Nom", rendezVous.PatientId);
            return View(rendezVous);
        }

        // POST: RendezVous/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedecinId,PatientId,Id,Date,Heure,Valider")] RendezVous rendezVous)
        {
            if (id != rendezVous.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rendezVous);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RendezVousExists(rendezVous.Id))
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
            ViewData["MedecinId"] = new SelectList(_context.Medecin, "Id", "Nom", rendezVous.MedecinId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Nom", rendezVous.PatientId);
            return View(rendezVous);
        }

        // GET: RendezVous/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezVous = await _context.RendezVous
                .Include(r => r.Medecin)
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rendezVous == null)
            {
                return NotFound();
            }

            return View(rendezVous);
        }

        // POST: RendezVous/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rendezVous = await _context.RendezVous.FindAsync(id);
            _context.RendezVous.Remove(rendezVous);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RendezVousExists(int id)
        {
            return _context.RendezVous.Any(e => e.Id == id);
        }
    }
}
