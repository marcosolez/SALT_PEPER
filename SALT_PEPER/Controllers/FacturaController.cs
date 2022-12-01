using Microsoft.AspNetCore.Mvc;
using SALT_PEPER.ENTIDADES;
using SALT_PEPER.NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SALT_PEPER.Controllers
{
    public class FacturaController : Controller
    {
        private readonly PlatilloBAL _context;
        private readonly OrdenBAL _contextOrden;

        public FacturaController()
        {
            _context = new PlatilloBAL();
            _contextOrden = new OrdenBAL();
        }
        public IActionResult Index()
        {
            ViewBag.Titulo = "Generar orden ";
            ViewBag.ListaPlatillos = _context.GetPlatilloPorParaSelect();

            return View(new List<TblPedido>());
        }

        [HttpGet]
        public JsonResult ListarOrdenes()
        {
            var ordenes = _contextOrden.GetAllOrdenesNoAnuladas();
            return Json(ordenes);
        }

        public IActionResult ListadoOrdenes()
        {
            return View();
        }
    }
}
