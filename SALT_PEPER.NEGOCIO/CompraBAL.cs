using SALT_PAPER.DATA;
using SALT_PEPER.ENTIDADES;
using SALT_PEPER.ENTIDADES.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALT_PEPER.NEGOCIO
{
    public class CompraBAL
    {
        CompraDAL _context;
        public CompraBAL()
        {
            _context = new CompraDAL();
        }
        public List<TblCompra> GetAllCompras()
        {
            return _context.GetAllCompras();
        }

        public bool GuardarCompra(CompraDTO model)
        {
            return _context.GuardarCompra(model);
        }

        public CompraDTO GetCompraPorPK(int? id)
        {
            return _context.GetCompraPorPK(id);
        }
    }
}
