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
    public class ProfessoriController : Controller
    {
        private readonly ClasseContext _context;

        public ProfessoriController(ClasseContext context)
        {
            _context = context;
        }

        // GET: Professori
        public async Task<IActionResult> Index()
        {
              return View(await _context.Professoris.ToListAsync());
        }

        // GET: Professori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Professoris == null)
            {
                return NotFound();
            }

            var professori = await _context.Professoris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professori == null)
            {
                return NotFound();
            }

            return View(professori);
        }

        // GET: Professori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Professore,Materia")] Professori professori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professori);
        }

        // GET: Professori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Professoris == null)
            {
                return NotFound();
            }

            var professori = await _context.Professoris.FindAsync(id);
            if (professori == null)
            {
                return NotFound();
            }
            return View(professori);
        }

        // POST: Professori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Professore,Materia")] Professori professori)
        {
            if (id != professori.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessoriExists(professori.Id))
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
            return View(professori);
        }

        // GET: Professori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Professoris == null)
            {
                return NotFound();
            }

            var professori = await _context.Professoris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professori == null)
            {
                return NotFound();
            }

            return View(professori);
        }

        // POST: Professori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Professoris == null)
            {
                return Problem("Entity set 'ClasseContext.Professoris'  is null.");
            }
            var professori = await _context.Professoris.FindAsync(id);
            if (professori != null)
            {
                _context.Professoris.Remove(professori);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessoriExists(int id)
        {
          return _context.Professoris.Any(e => e.Id == id);
        }
    }
}
