using SALT_PAPER.DATA;
using SALT_PEPER.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALT_PEPER.NEGOCIO
{
  public  class PlatilloBAL
    {
        PlatilloDAL _context;
        public PlatilloBAL()
        {
            _context = new PlatilloDAL();
        }
        public List<TblPlatilloBebida> GetAllPlatillos()
        {           
            return _context.GetAllPlatillos();
        }
    }
}
