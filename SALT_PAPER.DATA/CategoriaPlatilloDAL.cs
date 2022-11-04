using SALT_PEPER.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SALT_PAPER.DATA
{
   public class CategoriaPlatilloDAL
    {
        FAST_FOOD_DBContext _context;
        public CategoriaPlatilloDAL()
        {
            _context = new FAST_FOOD_DBContext();
        }
        public bool Add(TblCategoriaPlatillo model)
        {
            try
            {
                _context.TblCategoriaPlatillo.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(TblCategoriaPlatillo model)
        {
            try
            {
                _context.TblCategoriaPlatillo.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<TblCategoriaPlatillo> GetAll()
        {
            try
            {
                return _context.TblCategoriaPlatillo.ToList();
            }
            catch (Exception)
            {
                return new List<TblCategoriaPlatillo>();
            }
        }

        public List<TblCategoriaPlatillo> GetAllActive()
        {
            try
            {
                return _context.TblCategoriaPlatillo.Where(x=>x.Estado).ToList();
            }
            catch (Exception)
            {
                return new List<TblCategoriaPlatillo>();
            }
        }

        public TblCategoriaPlatillo GetById(int id)
        {
            try
            {
                return _context.TblCategoriaPlatillo.FirstOrDefault(x => x.Pk == id);
            }
            catch (Exception)
            {
                return new TblCategoriaPlatillo();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var model = _context.TblCategoriaPlatillo.FirstOrDefault(x => x.Pk == id);
                model.Estado = false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
