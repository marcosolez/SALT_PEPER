using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SALT_PEPER.ENTIDADES;
using SALT_PEPER.NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SALT_PEPER.Controllers
{
    public class IngredienteController : Controller
    {
        private readonly IngredienteBAL _context;
        private readonly UnidadesMedidaBAL _contextIUni;

        public IngredienteController()
        {
            _context = new IngredienteBAL();
            _contextIUni = new UnidadesMedidaBAL();
        }
        public IActionResult Index()
        {
            ViewBag.Titulo = "Ingredientes";
            return View(_context.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.Titulo = "Creación de ingredientes";
            ViewBag.ListUnidad= _contextIUni.GetAll().Where(x => x.Estado);
            return View();
        }

        // GET: Ingrediente/Details/5
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

            ViewBag.Titulo = "Ingrediente";
            return View(tblProveedor);
        }



        // POST: Ingrediente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pk,Nombre,Estado,Fkunidadmedida,Cantidadporunidad,Minimostock")] TblIngrediente tblIngrediente)
        {
            if (ModelState.IsValid)
            {
                var x = _context.Add(tblIngrediente);

                return RedirectToAction(nameof(Index));
            }
            return View(tblIngrediente);
        }

        // GET: Ingrediente/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIngrediente = _context.GetById(id);
            if (tblIngrediente == null)
            {
                return NotFound();
            }
            ViewBag.ListUnidad = _contextIUni.GetAll().Where(x => x.Estado);
            ViewBag.Titulo = "Ingrediente";
            return View(tblIngrediente);
        }

        // POST: Ingrediente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pk,Nombre,Estado,Fkunidadmedida,Cantidadporunidad,Minimostock")] TblIngrediente tblIngrediente)
        {
            if (id != tblIngrediente.Pk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblIngrediente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblIngredienteExists(tblIngrediente.Pk))
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
            return View(tblIngrediente);
        }

        // GET: Ingrediente/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIngrediente = _context.GetById(id);
            if (tblIngrediente == null)
            {
                return NotFound();
            }
            ViewBag.Titulo = "Ingrediente";
            return View(tblIngrediente);
        }

        // POST: Ingrediente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProveedor = _context.GetById(id);
            _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TblIngredienteExists(int id)
        {
            var exist = _context.GetById(id);
            return (exist != null) ? true : false;
        }
    }
}
