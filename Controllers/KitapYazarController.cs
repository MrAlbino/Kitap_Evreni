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
    public class KitapYazarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitapYazarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KitapYazars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KitapYazar.Include(k => k.Kitap).Include(k => k.Yazar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: KitapYazars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitapYazar = await _context.KitapYazar
                .Include(k => k.Kitap)
                .Include(k => k.Yazar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitapYazar == null)
            {
                return NotFound();
            }

            return View(kitapYazar);
        }

        // GET: KitapYazars/Create
        public IActionResult Create()
        {
            ViewData["KitapId"] = new SelectList(_context.Kitap, "Id", "Id");
            ViewData["YazarId"] = new SelectList(_context.Yazar, "Id", "Id");
            return View();
        }

        // POST: KitapYazars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KitapId,YazarId,YazarTip")] KitapYazar kitapYazar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitapYazar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KitapId"] = new SelectList(_context.Kitap, "Id", "Id", kitapYazar.KitapId);
            ViewData["YazarId"] = new SelectList(_context.Yazar, "Id", "Id", kitapYazar.YazarId);
            return View(kitapYazar);
        }

        // GET: KitapYazars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitapYazar = await _context.KitapYazar.FindAsync(id);
            if (kitapYazar == null)
            {
                return NotFound();
            }
            ViewData["KitapId"] = new SelectList(_context.Kitap, "Id", "Id", kitapYazar.KitapId);
            ViewData["YazarId"] = new SelectList(_context.Yazar, "Id", "Id", kitapYazar.YazarId);
            return View(kitapYazar);
        }

        // POST: KitapYazars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KitapId,YazarId,YazarTip")] KitapYazar kitapYazar)
        {
            if (id != kitapYazar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitapYazar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitapYazarExists(kitapYazar.Id))
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
            ViewData["KitapId"] = new SelectList(_context.Kitap, "Id", "Id", kitapYazar.KitapId);
            ViewData["YazarId"] = new SelectList(_context.Yazar, "Id", "Id", kitapYazar.YazarId);
            return View(kitapYazar);
        }

        // GET: KitapYazars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitapYazar = await _context.KitapYazar
                .Include(k => k.Kitap)
                .Include(k => k.Yazar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitapYazar == null)
            {
                return NotFound();
            }

            return View(kitapYazar);
        }

        // POST: KitapYazars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitapYazar = await _context.KitapYazar.FindAsync(id);
            _context.KitapYazar.Remove(kitapYazar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitapYazarExists(int id)
        {
            return _context.KitapYazar.Any(e => e.Id == id);
        }
    }
}
