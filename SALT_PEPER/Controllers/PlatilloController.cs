using Microsoft.AspNetCore.Mvc;
using SALT_PEPER.ENTIDADES;
using SALT_PEPER.NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SALT_PEPER.Controllers
{
    public class PlatilloController : Controller
    {
        private readonly PlatilloBAL _context;
        private readonly CategoriaPlatilloBAL _contextCat;

        public PlatilloController()
        {
            _context = new PlatilloBAL();
            _contextCat = new CategoriaPlatilloBAL();
        }
        public IActionResult Index()
        {
            var listado = _context.GetAllPlatillos();
            ViewBag.Titulo = "Listado platillos y bebidas";
            return View(listado);
        }

        public IActionResult CrearPlatillos(int? id)
        {         
            ViewBag.Titulo = "Creación de platillos y bebidas";
            ViewBag.ListCategorias = _contextCat.GetAllActive();
            if (id==null)
                return View(new TblPlatilloBebida());

            return View();
        }

    }
}
