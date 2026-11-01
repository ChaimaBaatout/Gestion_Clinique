using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion_Clinique.Data;
using Gestion_Clinique.Models;

namespace Gestion_Clinique.Controllers
{
    public class DateDeTravailsController : Controller
    {
        private readonly Gestion_CliniqueContext _context;

        public DateDeTravailsController(Gestion_CliniqueContext context)
        {
            _context = context;
        }

        // GET: DateDeTravails
        public async Task<IActionResult> Index()
        {
            return View(await _context.DateDeTravail.ToListAsync());
        }

        // GET: DateDeTravails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dateDeTravail = await _context.DateDeTravail
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dateDeTravail == null)
            {
                return NotFound();
            }

            return View(dateDeTravail);
        }

        // GET: DateDeTravails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DateDeTravails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Jours,HeurFin")] DateDeTravail dateDeTravail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dateDeTravail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dateDeTravail);
        }

        // GET: DateDeTravails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dateDeTravail = await _context.DateDeTravail.FindAsync(id);
            if (dateDeTravail == null)
            {
                return NotFound();
            }
            return View(dateDeTravail);
        }

        // POST: DateDeTravails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Jours,HeurFin")] DateDeTravail dateDeTravail)
        {
            if (id != dateDeTravail.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dateDeTravail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DateDeTravailExists(dateDeTravail.ID))
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
            return View(dateDeTravail);
        }

        // GET: DateDeTravails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dateDeTravail = await _context.DateDeTravail
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dateDeTravail == null)
            {
                return NotFound();
            }

            return View(dateDeTravail);
        }

        // POST: DateDeTravails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dateDeTravail = await _context.DateDeTravail.FindAsync(id);
            _context.DateDeTravail.Remove(dateDeTravail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DateDeTravailExists(int id)
        {
            return _context.DateDeTravail.Any(e => e.ID == id);
        }
    }
}
