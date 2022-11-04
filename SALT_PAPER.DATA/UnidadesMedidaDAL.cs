using SALT_PEPER.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SALT_PAPER.DATA
{
    public  class UnidadesMedidaDAL
    {
        FAST_FOOD_DBContext _context;
        public UnidadesMedidaDAL()
        {
            _context = new FAST_FOOD_DBContext();
        }
        public bool Add(TblUnidadMedida model)
        {
            try
            {
                _context.TblUnidadMedida.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Update(TblUnidadMedida model)
        {
            try
            {
                _context.TblUnidadMedida.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<TblUnidadMedida> GetAll()
        {
            try
            {
                return _context.TblUnidadMedida.ToList();               
            }
            catch (Exception ex)
            {
                return new List<TblUnidadMedida>();
            }
        }

        public TblUnidadMedida GetById(int id)
        {
            try
            {
                return _context.TblUnidadMedida.FirstOrDefault(x=>x.Pk==id);
            }
            catch (Exception ex)
            {
                return new TblUnidadMedida();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var model = _context.TblUnidadMedida.FirstOrDefault(x => x.Pk == id);
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
