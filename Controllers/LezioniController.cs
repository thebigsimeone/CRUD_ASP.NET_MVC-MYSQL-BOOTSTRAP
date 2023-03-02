using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimeoneCRUD.Models;

namespace SimeoneCRUD.Controllers
{
    public class LezioniController : Controller
    {
        private readonly ClasseContext _context;

        public LezioniController(ClasseContext context)
        {
            _context = context;
        }

        // GET: Lezioni
        public async Task<IActionResult> Index()
        {
              return View(await _context.Lezionis.ToListAsync());
        }

        // GET: Lezioni/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lezionis == null)
            {
                return NotFound();
            }

            var lezioni = await _context.Lezionis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lezioni == null)
            {
                return NotFound();
            }

            return View(lezioni);
        }

        // GET: Lezioni/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lezioni/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Lezione")] Lezioni lezioni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lezioni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lezioni);
        }

        // GET: Lezioni/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lezionis == null)
            {
                return NotFound();
            }

            var lezioni = await _context.Lezionis.FindAsync(id);
            if (lezioni == null)
            {
                return NotFound();
            }
            return View(lezioni);
        }

        // POST: Lezioni/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lezione")] Lezioni lezioni)
        {
            if (id != lezioni.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lezioni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LezioniExists(lezioni.Id))
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
            return View(lezioni);
        }

        // GET: Lezioni/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lezionis == null)
            {
                return NotFound();
            }

            var lezioni = await _context.Lezionis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lezioni == null)
            {
                return NotFound();
            }

            return View(lezioni);
        }

        // POST: Lezioni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lezionis == null)
            {
                return Problem("Entity set 'ClasseContext.Lezionis'  is null.");
            }
            var lezioni = await _context.Lezionis.FindAsync(id);
            if (lezioni != null)
            {
                _context.Lezionis.Remove(lezioni);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LezioniExists(int id)
        {
          return _context.Lezionis.Any(e => e.Id == id);
        }
    }
}
