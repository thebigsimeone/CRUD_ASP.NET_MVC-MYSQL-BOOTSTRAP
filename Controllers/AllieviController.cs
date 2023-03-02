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
    public class AllieviController : Controller
    {
        private readonly ClasseContext _context;

        public AllieviController(ClasseContext context)
        {
            _context = context;
        }

        // GET: Allievi
        public async Task<IActionResult> Index()
        {
              return View(await _context.Allievis.ToListAsync());
        }

        // GET: Allievi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Allievis == null)
            {
                return NotFound();
            }

            var allievi = await _context.Allievis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allievi == null)
            {
                return NotFound();
            }

            return View(allievi);
        }

        // GET: Allievi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Allievi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cognome,Idlezione")] Allievi allievi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allievi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allievi);
        }

        // GET: Allievi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Allievis == null)
            {
                return NotFound();
            }

            var allievi = await _context.Allievis.FindAsync(id);
            if (allievi == null)
            {
                return NotFound();
            }
            return View(allievi);
        }

        // POST: Allievi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cognome,Idlezione")] Allievi allievi)
        {
            if (id != allievi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allievi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllieviExists(allievi.Id))
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
            return View(allievi);
        }

        // GET: Allievi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Allievis == null)
            {
                return NotFound();
            }

            var allievi = await _context.Allievis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allievi == null)
            {
                return NotFound();
            }

            return View(allievi);
        }

        // POST: Allievi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Allievis == null)
            {
                return Problem("Entity set 'ClasseContext.Allievis'  is null.");
            }
            var allievi = await _context.Allievis.FindAsync(id);
            if (allievi != null)
            {
                _context.Allievis.Remove(allievi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllieviExists(int id)
        {
          return _context.Allievis.Any(e => e.Id == id);
        }
    }
}
