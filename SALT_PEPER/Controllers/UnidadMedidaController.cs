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
    public class UnidadMedidaController : Controller
    {
        private readonly UnidadesMedidaBAL _context;
       

        public UnidadMedidaController()
        {
            _context = new UnidadesMedidaBAL();
       
        }

        // GET: UnidadMedida
        public async Task<IActionResult> Index()
        {
            ViewBag.Titulo = "Unidad de medida";
            return View(_context.GetAll());
        }

        // GET: UnidadMedida/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUnidadMedida = _context.GetById(id);
               
            if (tblUnidadMedida == null)
            {
                return NotFound();
            }
            ViewBag.Titulo = "Unidad de medida";
            return View(tblUnidadMedida);
        }

        // GET: UnidadMedida/Create
        public IActionResult Create()
        {
            ViewBag.Titulo = "Unidad de medida";
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
                var x = _context.Add(tblUnidadMedida);
                return RedirectToAction(nameof(Index));
            }
            return View(tblUnidadMedida);
        }

        // GET: UnidadMedida/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUnidadMedida = _context.GetById(id);
            if (tblUnidadMedida == null)
            {
                return NotFound();
            }
            ViewBag.Titulo = "Unidad de medida";
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
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUnidadMedida =  _context.GetById(id);
            
            if (tblUnidadMedida == null)
            {
                return NotFound();
            }
            ViewBag.Titulo = "Unidad de medida";

            return View(tblUnidadMedida);
        }

        // POST: UnidadMedida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblUnidadMedida = _context.GetById(id);
            _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TblUnidadMedidaExists(int id)
        {
            var exist = _context.GetById(id);
            return (exist != null) ? true : false;
        }
    }
}
