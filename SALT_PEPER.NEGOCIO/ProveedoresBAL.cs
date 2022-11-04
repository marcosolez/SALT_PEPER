using SALT_PAPER.DATA;
using SALT_PEPER.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALT_PEPER.NEGOCIO
{
    public class ProveedoresBAL
    {
        ProveedoresDAL _context;
        public ProveedoresBAL()
        {
            _context = new ProveedoresDAL();
        }
        public bool Add(TblProveedor model)
        {
            return _context.Add(model);
        }

        public bool Update(TblProveedor model)
        {
            return _context.Update(model);
        }

        public bool Delete(int id)
        {
            return _context.Delete(id);
        }

        public List<TblProveedor> GetAll()
        {
            return _context.GetAll();
        }

        public TblProveedor GetById(int id)
        {
            return _context.GetById(id);
        }
    }
}
