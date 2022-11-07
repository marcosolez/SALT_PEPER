using Microsoft.EntityFrameworkCore;
using SALT_PEPER.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SALT_PAPER.DATA
{
   public class IngredienteDAL
    {
        FAST_FOOD_DBContext _context;
        public IngredienteDAL()
        {
            _context = new FAST_FOOD_DBContext();
        }

        public bool Add(TblIngrediente model)
        {
            try
            {
                _context.TblIngrediente.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Update(TblIngrediente model)
        {
            try
            {
                _context.TblIngrediente.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<TblIngrediente> GetAll()
        {
            try
            {
                return _context.TblIngrediente
                    .Include(x=>x.FkunidadmedidaNavigation).ToList();
            }
            catch (Exception ex)
            {
                return new List<TblIngrediente>();
            }
        }

        public List<TblIngrediente> GetAllActive()
        {
            try
            {
                return _context.TblIngrediente.Where(x => x.Estado).ToList();
            }
            catch (Exception)
            {
                return new List<TblIngrediente>();
            }
        }

        public TblIngrediente GetById(int id)
        {
            try
            {
                return _context.TblIngrediente.Include(x=>x.FkunidadmedidaNavigation).FirstOrDefault(x => x.Pk == id);
            }
            catch (Exception ex)
            {
                return new TblIngrediente();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var model = _context.TblIngrediente.FirstOrDefault(x => x.Pk == id);
                model.Estado = false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
