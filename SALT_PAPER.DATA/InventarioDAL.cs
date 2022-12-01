using SALT_PEPER.ENTIDADES;
using SALT_PEPER.ENTIDADES.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SALT_PAPER.DATA
{
  public  class InventarioDAL
    {
        FAST_FOOD_DBContext _context;
        public InventarioDAL()
        {
            _context = new FAST_FOOD_DBContext();
        }

        public List<InventarioDTO> GetInventario()
        {
            var query = (from inv in _context.TblInventario
                         join ing in _context.TblIngrediente on inv.Fkingrediente equals ing.Pk
                         join uni in _context.TblUnidadMedida on ing.Fkunidadmedida equals uni.Pk
                         orderby inv.Pk descending
                         select new InventarioDTO
                         {
                             FKINGREDIENTE=inv.Fkingrediente,
                             INGREDIENTE=ing.Nombre,
                             UNIDADMEDIDA=uni.Nombre,
                             FECHAACTUALIZACION=inv.Fechaiultimoingreso,
                             STOCK=inv.Cantidadstock,
                             STOCKMINIMO=ing.Minimostock
                         }).ToList();

            return query;
        }
    }
}
