using Microsoft.EntityFrameworkCore;
using SALT_PEPER.ENTIDADES;
using SALT_PEPER.ENTIDADES.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SALT_PAPER.DATA
{
  public  class CompraDAL
    {
        FAST_FOOD_DBContext _context;
        public CompraDAL()
        {
            _context = new FAST_FOOD_DBContext();
        }

        public List<TblCompra> GetAllCompras()
        {
            var listado = _context.TblCompra
                                 .Include(x => x.FkproveedorNavigation)
                                 .OrderByDescending(x=>x.Pk)
                                 .ToList();
            return listado;
        }

        public bool GuardarCompra(CompraDTO model)
        {

            using (var tran=_context.Database.BeginTransaction())
            {
                try
                {
                    //Guardando la compra
                    var compra = new TblCompra
                    {
                        Numfactura = model.NUMFACTURA,
                        Fechacompra = DateTime.Now,
                        Fkproveedor = model.FKPROVEEDOR,
                        Estado = true,
                        Username = model.USERNAME
                    };

                    _context.TblCompra.Add(compra);
                    _context.SaveChanges();

                    //Agregabdo detalles
                    var detalles = new List<TblDetalleCompra>();

                    foreach (var item in model.DETALLECOMPRADTO)
                    {
                        detalles.Add(new TblDetalleCompra
                        {
                            Fkcompra = compra.Pk,
                            Fkingrediente = item.FKINGREDIENTE,
                            Cantidadunidad = item.CANTIDADUNIDAD,
                            Precio = item.PRECIO,
                            Estado = true
                        });
                    }

                    _context.TblDetalleCompra.AddRange(detalles);
                    _context.SaveChanges();

                    tran.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return false;
                }


            }
        


        }

        public CompraDTO GetCompraPorPK(int? id)
        {
            var compra = _context.TblCompra
                                 .Include(x => x.TblDetalleCompra)
                                 .Where(x => x.Pk == id)
                                 .FirstOrDefault();

            var compraDTO = new CompraDTO
            {
                PK=compra.Pk,
                FECHACOMPRA=compra.Fechacompra,
                ESTADO=compra.Estado,
                FKPROVEEDOR=compra.Fkproveedor,
                USERNAME=compra.Username ,
                NUMFACTURA=compra.Numfactura
            };

            var detalleCompraDTO = new List<DetalleCompraDTO>();

            foreach (var item in compra.TblDetalleCompra)
            {
                detalleCompraDTO.Add(new DetalleCompraDTO
                {
                    PK=item.Pk,
                    FKINGREDIENTE=item.Fkingrediente,
                    CANTIDADUNIDAD=item.Cantidadunidad,
                    ESTADO=item.Estado,
                    FKCOMPRA=item.Fkcompra,
                    PRECIO=item.Precio
                });
            }

            compraDTO.DETALLECOMPRADTO = detalleCompraDTO;
            return compraDTO;
        }
    }
}
