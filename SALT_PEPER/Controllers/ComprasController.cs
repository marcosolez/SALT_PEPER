using Microsoft.AspNetCore.Mvc;
using SALT_PEPER.ENTIDADES.DTOs;
using SALT_PEPER.NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SALT_PEPER.Controllers
{
    public class ComprasController : Controller
    {

        private readonly CompraBAL _context;
        private readonly ProveedoresBAL _contextProv;
        private readonly IngredienteBAL _contextIngrediente;
        private readonly CategoriaPlatilloBAL _contextCat;
        private readonly UnidadesMedidaBAL _contextUnidMedida;
        public ComprasController()
        {
            _context = new CompraBAL();
            _contextProv = new ProveedoresBAL();
            _contextIngrediente = new IngredienteBAL();
            _contextCat = new CategoriaPlatilloBAL();
            _contextUnidMedida = new UnidadesMedidaBAL();
        }
        public IActionResult Index()
        {
            ViewBag.Titulo = "Listado de compras";
            return View(_context.GetAllCompras());
        }

        public IActionResult NuevaCompra(int? id)
        {
            var model = new CompraDTO();
            model.USERNAME = "Larix";

            if (id == null)
            {
                model.FECHACOMPRA = DateTime.Now;
                ViewBag.Titulo = "Nueva compra";
                model.PK = 0;
            }
            else
            {
                ViewBag.Titulo = "Detalle de compra";
                model = _context.GetCompraPorPK(id);
                ViewBag.ListCompras = model.DETALLECOMPRADTO;
            }

            ViewBag.Proveedores = _contextProv.GetAll()
                .Where(x => x.Estado).ToList();

            ViewBag.ListCategorias = _contextCat.GetAllActive();
            ViewBag.ListIngrediente = _contextIngrediente.GetAllActive();
            ViewBag.ListUnidadMedida = _contextUnidMedida.GetAll().Where(x => x.Estado).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult GuardaCompra([FromBody]CompraDTO compraDTO)
        {
            var resp = _context.GuardarCompra(compraDTO);
            return Json(new { data = resp });
        }
    }
}

