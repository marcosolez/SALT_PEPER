using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALT_PEPER.ENTIDADES;
using SALT_PEPER.ENTIDADES.DTOs;
using SALT_PEPER.NEGOCIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SALT_PEPER.Controllers
{
    public class PlatilloController : Controller
    {
        private readonly PlatilloBAL _context;
        private readonly CategoriaPlatilloBAL _contextCat;
        private readonly UnidadesMedidaBAL _contextUnidMedida;
        private readonly IngredienteBAL _contextIngrediente;
       
        private readonly IHostingEnvironment Environment;


        public PlatilloController(IHostingEnvironment _environment)
        {
            _context = new PlatilloBAL();
            _contextCat = new CategoriaPlatilloBAL();
            _contextUnidMedida = new UnidadesMedidaBAL();
            _contextIngrediente = new IngredienteBAL();
            
            Environment = _environment;
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
            ViewBag.ListIngrediente = _contextIngrediente.GetAllActive();
            ViewBag.ListUnidadMedida = _contextUnidMedida.GetAll().Where(x => x.Estado).ToList();

            if (id == null)
                return View(new PlatillosDTO() { IMAGEN = "image-preview.png", TIENEINGREDIENTE = false });

            var modelo = _context.ObtenerPlatilloBebida(id);
            if (modelo.IMAGEN == "")
                modelo.IMAGEN = "image-preview.png";

            ViewBag.ListIngredientes = modelo.LISTADOINGREDIENTE;

            if (modelo.LISTADOINGREDIENTE.Count > 0)
                modelo.TIENEINGREDIENTE = true;
            else
                modelo.TIENEINGREDIENTE = false;


            return View(modelo);
        }


        [HttpPost]
        public IActionResult GuardaActualizaPlatillo(PlatillosDTO platillosDTO)
        {
            if (platillosDTO.Files != null)
            {


                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                string path = Path.Combine(this.Environment.WebRootPath, "images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string ext = System.IO.Path.GetExtension(platillosDTO.Files.FileName);
                string newName = $"{ Guid.NewGuid().ToString()}{ ext }";

                //ELIMINANDO ARCHIVO
                if (platillosDTO.IMAGEN!="image-preview.png")
                {
                    string pathDelete = Path.Combine($"{this.Environment.WebRootPath}", "images", platillosDTO.IMAGEN);
                    if (System.IO.File.Exists(pathDelete))
                        System.IO.File.Delete(Path.Combine(pathDelete));
                    //Fin de eliminar
                }



                //Guardando archivo ARCHIVO
                using (FileStream stream = new FileStream(Path.Combine(path, newName), FileMode.Create))
                {
                    platillosDTO.Files.CopyTo(stream);
                    platillosDTO.IMAGEN = newName;
                }

            }          
            var resp = _context.GuardaActualizaPlatillo(platillosDTO);
            return Json(new { data = resp });
        }

    }


}
