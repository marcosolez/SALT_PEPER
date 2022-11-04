using Microsoft.EntityFrameworkCore;
using SALT_PEPER.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SALT_PAPER.DATA
{
   public class PlatilloDAL
    {
        FAST_FOOD_DBContext _context;
        public PlatilloDAL()
        {
            _context = new FAST_FOOD_DBContext();
        }

        public List<TblPlatilloBebida> GetAllPlatillos()
        {
            var listado = _context.TblPlatilloBebida
                                 .Include(x => x.FkcategoriaplatilloNavigation).ToList();
            return listado;
        }
    }
}
