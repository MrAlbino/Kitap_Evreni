using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Prog_Proje.Data;
using Web_Prog_Proje.Models;

namespace Web_Prog_Proje.Controllers
{
    public class KarakterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KarakterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Karakter
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Karakter.Include(k => k.Ulke);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Karakter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karakter = await _context.Karakter
                .Include(k => k.Ulke)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karakter == null)
            {
                return NotFound();
            }

            return View(karakter);
        }

        // GET: Karakter/Create
        public IActionResult Create()
        {
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "Id");
            return View();
        }

        // POST: Karakter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Soyad,UlkeId")] Karakter karakter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(karakter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "Id", karakter.UlkeId);
            return View(karakter);
        }

        // GET: Karakter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karakter = await _context.Karakter.FindAsync(id);
            if (karakter == null)
            {
                return NotFound();
            }
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "Id", karakter.UlkeId);
            return View(karakter);
        }

        // POST: Karakter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Soyad,UlkeId")] Karakter karakter)
        {
            if (id != karakter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(karakter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KarakterExists(karakter.Id))
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
            ViewData["UlkeId"] = new SelectList(_context.Ulke, "Id", "Id", karakter.UlkeId);
            return View(karakter);
        }

        // GET: Karakter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karakter = await _context.Karakter
                .Include(k => k.Ulke)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karakter == null)
            {
                return NotFound();
            }

            return View(karakter);
        }

        // POST: Karakter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var karakter = await _context.Karakter.FindAsync(id);
            _context.Karakter.Remove(karakter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KarakterExists(int id)
        {
            return _context.Karakter.Any(e => e.Id == id);
        }
    }
}
