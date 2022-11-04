using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SALT_PEPER.ENTIDADES;
using SALT_PEPER.NEGOCIO;

namespace SALT_PEPER.Controllers
{
    public class CategoriaPlatilloController : Controller
    {
        private readonly CategoriaPlatilloBAL _context;

        public CategoriaPlatilloController()
        {
            _context = new CategoriaPlatilloBAL();
        }

        // GET: CategoriaPlatillo
        public async Task<IActionResult> Index()
        {
            ViewBag.Titulo = "Categoría platillo";
            return View(_context.GetAll());
        }

        // GET: CategoriaPlatillo/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedor = _context.GetById(id);
            if (tblProveedor == null)
            {
                return NotFound();
            }

            ViewBag.Titulo = "Categoría platillo";
            return View(tblProveedor);
        }

        // GET: CategoriaPlatillo/Create
        public IActionResult Create()
        {
            ViewBag.Titulo = "Categoría platillo";
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
                var x = _context.Add(tblCategoriaPlatillo);

                return RedirectToAction(nameof(Index));
            }
            return View(tblCategoriaPlatillo);
        }

        // GET: CategoriaPlatillo/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCategoriaPlatillo = _context.GetById(id);
            if (tblCategoriaPlatillo == null)
            {
                return NotFound();
            }
            ViewBag.Titulo = "Categoría platillo";
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
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCategoriaPlatillo = _context.GetById(id);
            if (tblCategoriaPlatillo == null)
            {
                return NotFound();
            }
            ViewBag.Titulo = "Categoría platillo";
            return View(tblCategoriaPlatillo);
        }

        // POST: CategoriaPlatillo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProveedor = _context.GetById(id);
            _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TblCategoriaPlatilloExists(int id)
        {
            var exist = _context.GetById(id);
            return (exist != null) ? true : false;
        }
    }
}
