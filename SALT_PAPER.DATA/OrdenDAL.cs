using Microsoft.EntityFrameworkCore;
using SALT_PEPER.ENTIDADES;
using SALT_PEPER.ENTIDADES.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SALT_PAPER.DATA
{
   public class OrdenDAL
    {
        FAST_FOOD_DBContext _context;
        public OrdenDAL()
        {
            _context = new FAST_FOOD_DBContext();
        }

        public List<OrdenDTO> GetAllOrdenesNoAnuladas()
        {
            var listado = new List<OrdenDTO>();

            var orden = _context.TblPedido
                                 .Include(x => x.TblDetallePedido)
                                 .Include("TblDetallePedido.FkplatillobebidaNavigation").ToList();
            foreach (var item in orden)
            {
                var obj = new OrdenDTO
                {
                    PK = item.Pk,
                    FECHAPEDIDO = item.Fechapedido,
                    USERNAME = item.Username,
                    ESTADOORDEN = item.Estadoorden,
                    NOMBRECLIENTE=item.Nombrecliente,
                    FECHASTRING= item.Fechapedido.ToString(),
                    SUBTOTAL=item.TblDetallePedido.Sum(x=>x.Subtotal)

                };

                obj.ORDENES = new List<OrdenesDTO>();

                foreach (var detail in item.TblDetallePedido)
                {
                    obj.ORDENES.Add(new OrdenesDTO
                    {
                        PK=detail.Pk,
                        FKPEDIDO=detail.Fkpedido,
                        FKPLATILLO=detail.Fkplatillobebida,
                        CANTIDAD=detail.Cantidad,
                        PLATILLO=detail.FkplatillobebidaNavigation.Nombre,
                        PRECIO=detail.Precio,
                        SUBTOTAL=detail.Subtotal,
                        IMAGEN=detail.FkplatillobebidaNavigation.Imagen                        
                    });
                }


                listado.Add(obj);
            }
            return listado;
        }
    }
}
