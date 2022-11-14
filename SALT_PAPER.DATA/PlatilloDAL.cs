using Microsoft.EntityFrameworkCore;
using SALT_PEPER.ENTIDADES;
using SALT_PEPER.ENTIDADES.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SALT_PAPER.DATA
{
    public class PlatilloDAL
    {
        FAST_FOOD_DBContext _context;
        public PlatilloDAL()
        {
            _context = new FAST_FOOD_DBContext();
        }

        public List<TblPlatilloBebida> GetAllPlatillos()
        {
            var listado = _context.TblPlatilloBebida
                                 .Include(x => x.FkcategoriaplatilloNavigation).ToList();
            return listado;
        }

        public PlatillosDTO ObtenerPlatilloBebida(int? pk)
        {
            var platillo = _context.TblPlatilloBebida
                            .Include(x => x.TblIngredientePlatillo).FirstOrDefault(x => x.Pk == pk);

            var modelo = new PlatillosDTO();
            if (platillo != null)
            {
                modelo.PK = platillo.Pk;
                modelo.NOMBRE = platillo.Nombre;
                modelo.DESCRIPCION = platillo.Descripcion;
                modelo.FKCATEGORIAPLATILLO = platillo.Fkcategoriaplatillo;
                modelo.ESTADO = platillo.Estado;
                modelo.IMAGEN = platillo.Imagen;
                modelo.PRECIO = platillo.Precio;
                modelo.LISTADOINGREDIENTE = new List<IngredinetesDTO>();

                foreach (var item in platillo.TblIngredientePlatillo)
                {
                    modelo.LISTADOINGREDIENTE.Add(
                        new IngredinetesDTO
                        {
                            PK = item.Pk,
                            FKINGREDIENTE = item.Fkingrediente,
                            FKPLATILLO = item.Fkplatillo,
                            CANTIDADUNIDAD = item.Cantidadunidad
                        });
                }
                return modelo;
            }
            return new PlatillosDTO();
        }


        public bool GuardaActualizaPlatillo(PlatillosDTO model)
        {
            var result = false;
            var Platillo = new TblPlatilloBebida
            {
                Pk = model.PK,
                Nombre = model.NOMBRE,
                Descripcion = model.DESCRIPCION,
                Fkcategoriaplatillo = model.FKCATEGORIAPLATILLO,
                Estado = model.ESTADO,
                Precio = model.PRECIO,
                Imagen = model.IMAGEN
            };
            var Ingredientes = new List<TblIngredientePlatillo>();

            if (model.LISTADOINGREDIENTE == null)
                model.LISTADOINGREDIENTE = new List<IngredinetesDTO>();

            if (model.LISTADOINGREDIENTE.Count > 0)
            {
                foreach (var item in model.LISTADOINGREDIENTE)
                {
                    Ingredientes.Add(new TblIngredientePlatillo
                    {
                        Pk=item.PK,
                        Fkingrediente = item.FKINGREDIENTE,
                        Fkplatillo = Platillo.Pk,
                        Cantidadunidad = item.CANTIDADUNIDAD
                    });
                }
            }

            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    if (Platillo.Pk == 0)
                    {
                        _context.TblPlatilloBebida.Add(Platillo);
                        _context.SaveChanges();
                        Ingredientes.ForEach(x => x.Fkplatillo = Platillo.Pk);
                        _context.TblIngredientePlatillo.AddRange(Ingredientes);
                    }

                    else
                    {
                        var listaIngredienteDelete = _context.TblIngredientePlatillo.Where(x => x.Fkplatillo == Platillo.Pk).ToList();  
                        _context.TblIngredientePlatillo.RemoveRange(listaIngredienteDelete);                      

          
                        //Actualizando Platillo
                        _context.TblPlatilloBebida.Update(Platillo);
                        //Agregando ingredientes
                        Ingredientes.ForEach(x => x.FkplatilloNavigation = null);
                        _context.TblIngredientePlatillo.AddRange(Ingredientes);

                       

                    }
                    _context.SaveChanges();
                    tran.Commit();
                    result = true;
                }
                catch (Exception ex)
                {

                    tran.Rollback();
                }

            }
            return result;
        }

    }
}

