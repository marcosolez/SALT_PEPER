using SALT_PAPER.DATA;
using SALT_PEPER.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALT_PEPER.NEGOCIO
{
   public class UnidadesMedidaBAL
    {
        UnidadesMedidaDAL _context;
        public UnidadesMedidaBAL()
        {
            _context = new UnidadesMedidaDAL();
        }
        public bool Add(TblUnidadMedida model)
        {
            return _context.Add(model);
        }

        public bool Update(TblUnidadMedida model)
        {
            return _context.Update(model);
        }

        public List<TblUnidadMedida> GetAll()
        {
            return _context.GetAll();
        }

        public bool Delete(int id)
        {
            return _context.Delete(id);
        }

        public TblUnidadMedida GetById(int id)
        {
            return _context.GetById(id);
        }
    }
}
