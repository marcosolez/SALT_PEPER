using SALT_PAPER.DATA;
using SALT_PEPER.ENTIDADES.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALT_PEPER.NEGOCIO
{
    public class OrdenBAL
    {
        OrdenDAL _context;
        public OrdenBAL()
        {
            _context = new OrdenDAL();
        }
        public List<OrdenDTO> GetAllOrdenesNoAnuladas()
        {
            return _context.GetAllOrdenesNoAnuladas();
        }
    }
}
