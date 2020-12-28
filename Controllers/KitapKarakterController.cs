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
    public class KitapKarakterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitapKarakterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KitapKarakter
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KitapKarakter.Include(k => k.Karakter).Include(k => k.Kitap);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: KitapKarakter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitapKarakter = await _context.KitapKarakter
                .Include(k => k.Karakter)
                .Include(k => k.Kitap)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitapKarakter == null)
            {
                return NotFound();
            }

            return View(kitapKarakter);
        }

        // GET: KitapKarakter/Create
        public IActionResult Create()
        {
            ViewData["KarakterId"] = new SelectList(_context.Karakter, "Id", "AdSoyad");
            ViewData["KitapId"] = new SelectList(_context.Kitap, "Id", "KitapAd");
            return View();
        }

        // POST: KitapKarakter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KitapId,KarakterId,Sira")] KitapKarakter kitapKarakter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitapKarakter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KarakterId"] = new SelectList(_context.Karakter, "Id", "AdSoyad", kitapKarakter.KarakterId);
            ViewData["KitapId"] = new SelectList(_context.Kitap, "Id", "KitapAd", kitapKarakter.KitapId);
            return View(kitapKarakter);
        }

        // GET: KitapKarakter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitapKarakter = await _context.KitapKarakter.FindAsync(id);
            if (kitapKarakter == null)
            {
                return NotFound();
            }
            ViewData["KarakterId"] = new SelectList(_context.Karakter, "Id", "AdSoyad", kitapKarakter.KarakterId);
            ViewData["KitapId"] = new SelectList(_context.Kitap, "Id", "KitapAd", kitapKarakter.KitapId);
            return View(kitapKarakter);
        }

        // POST: KitapKarakter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KitapId,KarakterId,Sira")] KitapKarakter kitapKarakter)
        {
            if (id != kitapKarakter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitapKarakter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitapKarakterExists(kitapKarakter.Id))
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
            ViewData["KarakterId"] = new SelectList(_context.Karakter, "Id", "AdSoyad", kitapKarakter.KarakterId);
            ViewData["KitapId"] = new SelectList(_context.Kitap, "Id", "KitapAd", kitapKarakter.KitapId);
            return View(kitapKarakter);
        }

        // GET: KitapKarakter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitapKarakter = await _context.KitapKarakter
                .Include(k => k.Karakter)
                .Include(k => k.Kitap)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitapKarakter == null)
            {
                return NotFound();
            }

            return View(kitapKarakter);
        }

        // POST: KitapKarakter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitapKarakter = await _context.KitapKarakter.FindAsync(id);
            _context.KitapKarakter.Remove(kitapKarakter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitapKarakterExists(int id)
        {
            return _context.KitapKarakter.Any(e => e.Id == id);
        }
    }
}
