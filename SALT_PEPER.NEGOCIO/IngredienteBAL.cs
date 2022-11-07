using SALT_PAPER.DATA;
using SALT_PEPER.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALT_PEPER.NEGOCIO
{
   public class IngredienteBAL
    {
        IngredienteDAL _context;
        public IngredienteBAL()
        {
            _context = new IngredienteDAL();
        }
        public bool Add(TblIngrediente model)
        {
            return _context.Add(model);
        }

        public bool Update(TblIngrediente model)
        {
            return _context.Update(model);
        }

        public bool Delete(int id)
        {
            return _context.Delete(id);
        }

        public List<TblIngrediente> GetAll()
        {
            return _context.GetAll();
        }
        public List<TblIngrediente> GetAllActive()
        {
            return _context.GetAllActive();
        }

        public TblIngrediente GetById(int id)
        {
            return _context.GetById(id);
        }
    }
}
