using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Prog_Proje.Data;
using Web_Prog_Proje.Models;

namespace Web_Prog_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class YorumlarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YorumlarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yorumlar
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Yorumlar.Include(y => y.Kitap);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Yorumlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorumlar = await _context.Yorumlar
                .Include(y => y.Kitap)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yorumlar == null)
            {
                return NotFound();
            }

            return View(yorumlar);
        }

        // GET: Yorumlar/Create
        public IActionResult Create()
        {
            ViewData["KitapId"] = new SelectList(_context.Kitap, "Id", "KitapAd");
            return View();
        }

        // POST: Yorumlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Soyad,Mail,Yorum,KitapId")] Yorumlar yorumlar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yorumlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KitapId"] = new SelectList(_context.Kitap, "Id", "KitapAd", yorumlar.KitapId);
            return View(yorumlar);
        }

        // GET: Yorumlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorumlar = await _context.Yorumlar.FindAsync(id);
            if (yorumlar == null)
            {
                return NotFound();
            }
            ViewData["KitapId"] = new SelectList(_context.Kitap, "Id", "KitapAd", yorumlar.KitapId);
            return View(yorumlar);
        }

        // POST: Yorumlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Soyad,Mail,Yorum,KitapId")] Yorumlar yorumlar)
        {
            if (id != yorumlar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yorumlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YorumlarExists(yorumlar.Id))
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
            ViewData["KitapId"] = new SelectList(_context.Kitap, "Id", "KitapAd", yorumlar.KitapId);
            return View(yorumlar);
        }

        // GET: Yorumlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorumlar = await _context.Yorumlar
                .Include(y => y.Kitap)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yorumlar == null)
            {
                return NotFound();
            }

            return View(yorumlar);
        }

        // POST: Yorumlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yorumlar = await _context.Yorumlar.FindAsync(id);
            _context.Yorumlar.Remove(yorumlar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YorumlarExists(int id)
        {
            return _context.Yorumlar.Any(e => e.Id == id);
        }
    }
}
