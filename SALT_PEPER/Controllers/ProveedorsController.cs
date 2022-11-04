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
    public class ProveedorsController : Controller
    {
        private readonly ProveedoresBAL _context;

        public ProveedorsController()
        {
            _context = new ProveedoresBAL();
        }

        // GET: Proveedors
        public async Task<IActionResult> Index()
        {
            ViewBag.Titulo = "Proveedores";
            return View(_context.GetAll());
        }

        // GET: Proveedors/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedor =  _context.GetById(id);
            if (tblProveedor == null)
            {
                return NotFound();
            }
            ViewBag.Titulo = "Proveedores";
            return View(tblProveedor);
        }

        // GET: Proveedors/Create
        public IActionResult Create()
        {
            ViewBag.Titulo = "Proveedores";
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
               var x= _context.Add(tblProveedor);
               
                return RedirectToAction(nameof(Index));
            }
           
            return View(tblProveedor);
        }

        // GET: Proveedors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedor =  _context.GetById(id);
            if (tblProveedor == null)
            {
                return NotFound();
            }
            ViewBag.Titulo = "Proveedores";
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
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedor =  _context.GetById(id);
               
            if (tblProveedor == null)
            {
                return NotFound();
            }
            ViewBag.Titulo = "Proveedores";
            return View(tblProveedor);
        }

        // POST: Proveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProveedor =  _context.GetById(id);           
             _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TblProveedorExists(int id)
        {
            var exist = _context.GetById(id);
            return (exist != null) ? true : false;
        }
    }
}
