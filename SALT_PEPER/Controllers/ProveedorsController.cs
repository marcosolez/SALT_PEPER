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
    public class ProveedorsController : Controller
    {
        private readonly FAST_FOOD_DBContext _context;

        public ProveedorsController(FAST_FOOD_DBContext context)
        {
            _context = context;
        }

        // GET: Proveedors
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblProveedor.ToListAsync());
        }

        // GET: Proveedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedor = await _context.TblProveedor
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (tblProveedor == null)
            {
                return NotFound();
            }

            return View(tblProveedor);
        }

        // GET: Proveedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proveedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pk,Nombre,Telefono,Direccion,Estado")] TblProveedor tblProveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblProveedor);
        }

        // GET: Proveedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedor = await _context.TblProveedor.FindAsync(id);
            if (tblProveedor == null)
            {
                return NotFound();
            }
            return View(tblProveedor);
        }

        // POST: Proveedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pk,Nombre,Telefono,Direccion,Estado")] TblProveedor tblProveedor)
        {
            if (id != tblProveedor.Pk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProveedorExists(tblProveedor.Pk))
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
            return View(tblProveedor);
        }

        // GET: Proveedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedor = await _context.TblProveedor
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (tblProveedor == null)
            {
                return NotFound();
            }

            return View(tblProveedor);
        }

        // POST: Proveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProveedor = await _context.TblProveedor.FindAsync(id);
            _context.TblProveedor.Remove(tblProveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProveedorExists(int id)
        {
            return _context.TblProveedor.Any(e => e.Pk == id);
        }
    }
}
