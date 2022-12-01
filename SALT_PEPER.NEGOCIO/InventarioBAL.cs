using SALT_PAPER.DATA;
using SALT_PEPER.ENTIDADES.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALT_PEPER.NEGOCIO
{
  public  class InventarioBAL
    {
        InventarioDAL _context;
        public InventarioBAL()
        {
            _context = new InventarioDAL();
        }
        public List<InventarioDTO> GetInventario()
        {
            return _context.GetInventario();
        }
    }
}
