using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StomatoloskaPoliklinika.Data;
using StomatoloskaPoliklinika.Models;

namespace StomatoloskaPoliklinika.Controllers
{
    public class UgovoreniSastanakController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UgovoreniSastanakController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UgovoreniSastanak
        public async Task<IActionResult> Index()
        {
              return _context.UgovoreniSastanak != null ? 
                          View(await _context.UgovoreniSastanak.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UgovoreniSastanak'  is null.");
        }

        // GET: UgovoreniSastanak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UgovoreniSastanak == null)
            {
                return NotFound();
            }

            var ugovoreniSastanak = await _context.UgovoreniSastanak
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ugovoreniSastanak == null)
            {
                return NotFound();
            }

            return View(ugovoreniSastanak);
        }

        // GET: UgovoreniSastanak/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UgovoreniSastanak/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DatumVrijeme,Status,PacijentId")] UgovoreniSastanak ugovoreniSastanak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ugovoreniSastanak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ugovoreniSastanak);
        }

        // GET: UgovoreniSastanak/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UgovoreniSastanak == null)
            {
                return NotFound();
            }

            var ugovoreniSastanak = await _context.UgovoreniSastanak.FindAsync(id);
            if (ugovoreniSastanak == null)
            {
                return NotFound();
            }
            return View(ugovoreniSastanak);
        }

        // POST: UgovoreniSastanak/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DatumVrijeme,Status,PacijentId")] UgovoreniSastanak ugovoreniSastanak)
        {
            if (id != ugovoreniSastanak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ugovoreniSastanak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UgovoreniSastanakExists(ugovoreniSastanak.Id))
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
            return View(ugovoreniSastanak);
        }

        // GET: UgovoreniSastanak/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UgovoreniSastanak == null)
            {
                return NotFound();
            }

            var ugovoreniSastanak = await _context.UgovoreniSastanak
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ugovoreniSastanak == null)
            {
                return NotFound();
            }

            return View(ugovoreniSastanak);
        }

        // POST: UgovoreniSastanak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UgovoreniSastanak == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UgovoreniSastanak'  is null.");
            }
            var ugovoreniSastanak = await _context.UgovoreniSastanak.FindAsync(id);
            if (ugovoreniSastanak != null)
            {
                _context.UgovoreniSastanak.Remove(ugovoreniSastanak);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UgovoreniSastanakExists(int id)
        {
          return (_context.UgovoreniSastanak?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
