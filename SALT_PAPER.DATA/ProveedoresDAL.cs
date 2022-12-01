using SALT_PEPER.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SALT_PAPER.DATA
{
  public  class ProveedoresDAL
    {
        FAST_FOOD_DBContext _context;
        public ProveedoresDAL()
        {
            _context = new FAST_FOOD_DBContext();
        }       

        public bool Add(TblProveedor model)
        {
            try
            {
                _context.TblProveedor.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(TblProveedor model)
        {
            try
            {
                _context.TblProveedor.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<TblProveedor> GetAll()
        {
            try
            {
                return _context.TblProveedor.ToList();
            }
            catch (Exception)
            {
                return new List<TblProveedor>();
            }
        }

        public TblProveedor GetById(int id)
        {
            try
            {
                return _context.TblProveedor.FirstOrDefault(x => x.Pk == id);
            }
            catch (Exception)
            {
                return new TblProveedor();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var model = _context.TblProveedor.FirstOrDefault(x => x.Pk == id);               
                model.Estado = false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}
