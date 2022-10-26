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
    public class UnidadMedidaController : Controller
    {
        private readonly FAST_FOOD_DBContext _context;

        public UnidadMedidaController(FAST_FOOD_DBContext context)
        {
            _context = context;
        }

        // GET: UnidadMedida
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblUnidadMedida.ToListAsync());
        }

        // GET: UnidadMedida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUnidadMedida = await _context.TblUnidadMedida
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (tblUnidadMedida == null)
            {
                return NotFound();
            }

            return View(tblUnidadMedida);
        }

        // GET: UnidadMedida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnidadMedida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pk,Nombre,Estado")] TblUnidadMedida tblUnidadMedida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblUnidadMedida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblUnidadMedida);
        }

        // GET: UnidadMedida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUnidadMedida = await _context.TblUnidadMedida.FindAsync(id);
            if (tblUnidadMedida == null)
            {
                return NotFound();
            }
            return View(tblUnidadMedida);
        }

        // POST: UnidadMedida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pk,Nombre,Estado")] TblUnidadMedida tblUnidadMedida)
        {
            if (id != tblUnidadMedida.Pk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUnidadMedida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUnidadMedidaExists(tblUnidadMedida.Pk))
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
            return View(tblUnidadMedida);
        }

        // GET: UnidadMedida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUnidadMedida = await _context.TblUnidadMedida
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (tblUnidadMedida == null)
            {
                return NotFound();
            }

            return View(tblUnidadMedida);
        }

        // POST: UnidadMedida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblUnidadMedida = await _context.TblUnidadMedida.FindAsync(id);
            _context.TblUnidadMedida.Remove(tblUnidadMedida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUnidadMedidaExists(int id)
        {
            return _context.TblUnidadMedida.Any(e => e.Pk == id);
        }
    }
}
