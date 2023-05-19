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
    public class StomatologController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StomatologController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stomatolog
        public async Task<IActionResult> Index()
        {
              return _context.Stomatolog != null ? 
                          View(await _context.Stomatolog.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Stomatolog'  is null.");
        }

        // GET: Stomatolog/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // GET: Stomatolog/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            SearchPhrase = SearchPhrase.ToLower();
            return View("Index", await _context.Stomatolog
                .Where(s => (s.Prezime+" "+s.Ime).ToLower().Contains(SearchPhrase) || (s.Ime+" "+s.Prezime).ToLower().Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Stomatolog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stomatolog == null)
            {
                return NotFound();
            }

            var stomatolog = await _context.Stomatolog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stomatolog == null)
            {
                return NotFound();
            }

            return View(stomatolog);
        }

        // GET: Stomatolog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stomatolog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,BrojTelefona,Email,Lozinka,Specijalizacija,Cijena")] Stomatolog stomatolog)
        {
            if (ModelState.IsValid)
            {
                // Perform password validation
                if (!IsPasswordValid(stomatolog.Lozinka))
                {
                    ModelState.AddModelError("Lozinka", "The password must be at least 6 characters long and contain both letters and numbers.");
                    return View(stomatolog);
                }

                _context.Add(stomatolog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(stomatolog);
        }

        // GET: Stomatolog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stomatolog == null)
            {
                return NotFound();
            }

            var stomatolog = await _context.Stomatolog.FindAsync(id);
            if (stomatolog == null)
            {
                return NotFound();
            }
            return View(stomatolog);
        }

        // POST: Stomatolog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,BrojTelefona,Email,Lozinka,Specijalizacija,Cijena")] Stomatolog stomatolog)
        {
            if (id != stomatolog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stomatolog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StomatologExists(stomatolog.Id))
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
            return View(stomatolog);
        }

        // GET: Stomatolog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stomatolog == null)
            {
                return NotFound();
            }

            var stomatolog = await _context.Stomatolog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stomatolog == null)
            {
                return NotFound();
            }

            return View(stomatolog);
        }

        // POST: Stomatolog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stomatolog == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Stomatolog'  is null.");
            }
            var stomatolog = await _context.Stomatolog.FindAsync(id);
            if (stomatolog != null)
            {
                _context.Stomatolog.Remove(stomatolog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StomatologExists(int id)
        {
          return (_context.Stomatolog?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private bool IsPasswordValid(string password)
        {
            // Check if the password is at least 6 characters long
            if (password.Length < 6)
            {
                return false;
            }

            // Check if the password contains both letters and numbers
            bool hasLetters = false;
            bool hasNumbers = false;

            foreach (char c in password)
            {
                if (char.IsLetter(c))
                {
                    hasLetters = true;
                }
                else if (char.IsDigit(c))
                {
                    hasNumbers = true;
                }

                // If we have found both letters and numbers, no need to continue checking
                if (hasLetters && hasNumbers)
                {
                    break;
                }
            }

            return hasLetters && hasNumbers;
        }
    }
}
