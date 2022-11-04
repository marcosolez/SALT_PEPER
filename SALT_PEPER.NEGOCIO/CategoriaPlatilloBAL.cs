using SALT_PAPER.DATA;
using SALT_PEPER.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALT_PEPER.NEGOCIO
{
   public class CategoriaPlatilloBAL
    {
        CategoriaPlatilloDAL _context;
        public CategoriaPlatilloBAL()
        {
            _context = new CategoriaPlatilloDAL();
        }
        public bool Add(TblCategoriaPlatillo model)
        {
            return _context.Add(model);
        }

        public bool Update(TblCategoriaPlatillo model)
        {
            return _context.Update(model);
        }

        public bool Delete  (int id)
        {
            return _context.Delete(id);
        }

        public List<TblCategoriaPlatillo> GetAll()
        {
            return _context.GetAll();
        }
        public List<TblCategoriaPlatillo> GetAllActive()
        {
            return _context.GetAllActive();
        }

            public TblCategoriaPlatillo GetById(int id)
        {
            return _context.GetById(id);
        }
    }
}
