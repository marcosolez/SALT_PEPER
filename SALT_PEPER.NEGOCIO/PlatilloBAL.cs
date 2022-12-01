using SALT_PAPER.DATA;
using SALT_PEPER.ENTIDADES;
using SALT_PEPER.ENTIDADES.DTOs;
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

        public PlatillosDTO ObtenerPlatilloBebida(int? pk)
        {
            return _context.ObtenerPlatilloBebida(pk);
        }

        public bool GuardaActualizaPlatillo(PlatillosDTO model)
        {
            if (model.IMAGEN==null)            
                model.IMAGEN = "image-preview.png";
            
            return _context.GuardaActualizaPlatillo(model);
        }

        public List<PlatillosDTO> GetPlatilloPorParaSelect()
        {
            return _context.GetPlatilloPorParaSelect();
        }
    }
}
