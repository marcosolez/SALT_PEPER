using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SALT_PEPER.Models;

namespace SALT_PEPER.Controllers
{
    public class CategoriaPlatilloController : Controller
    {
        private readonly FAST_FOOD_DBContext _context;

        public CategoriaPlatilloController(FAST_FOOD_DBContext context)
        {
            _context = context;
        }

        // GET: CategoriaPlatillo
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblCategoriaPlatillo.ToListAsync());
        }

        // GET: CategoriaPlatillo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCategoriaPlatillo = await _context.TblCategoriaPlatillo
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (tblCategoriaPlatillo == null)
            {
                return NotFound();
            }

            return View(tblCategoriaPlatillo);
        }

        // GET: CategoriaPlatillo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaPlatillo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pk,Nombre,Estado")] TblCategoriaPlatillo tblCategoriaPlatillo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCategoriaPlatillo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCategoriaPlatillo);
        }

        // GET: CategoriaPlatillo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCategoriaPlatillo = await _context.TblCategoriaPlatillo.FindAsync(id);
            if (tblCategoriaPlatillo == null)
            {
                return NotFound();
            }
            return View(tblCategoriaPlatillo);
        }

        // POST: CategoriaPlatillo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pk,Nombre,Estado")] TblCategoriaPlatillo tblCategoriaPlatillo)
        {
            if (id != tblCategoriaPlatillo.Pk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCategoriaPlatillo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCategoriaPlatilloExists(tblCategoriaPlatillo.Pk))
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
            return View(tblCategoriaPlatillo);
        }

        // GET: CategoriaPlatillo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCategoriaPlatillo = await _context.TblCategoriaPlatillo
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (tblCategoriaPlatillo == null)
            {
                return NotFound();
            }

            return View(tblCategoriaPlatillo);
        }

        // POST: CategoriaPlatillo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCategoriaPlatillo = await _context.TblCategoriaPlatillo.FindAsync(id);
            _context.TblCategoriaPlatillo.Remove(tblCategoriaPlatillo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCategoriaPlatilloExists(int id)
        {
            return _context.TblCategoriaPlatillo.Any(e => e.Pk == id);
        }
    }
}
