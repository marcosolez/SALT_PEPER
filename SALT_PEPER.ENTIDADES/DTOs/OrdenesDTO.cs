using System;
using System.Collections.Generic;
using System.Text;

namespace SALT_PEPER.ENTIDADES.DTOs
{

    public class OrdenDTO
    {
        public int PK { get; set; }
        public DateTime FECHAPEDIDO { get; set; }
        public string FECHASTRING { get; set; }
        public bool ANULADO { get; set; }
        public string USERNAME { get; set; }
        public string ESTADOORDEN { get; set; }
        public string NOMBRECLIENTE { get; set; }
        public decimal SUBTOTAL { get; set; }

        public List<OrdenesDTO> ORDENES  { get; set; }
    }
  public  class OrdenesDTO
    {
        public int PK { get; set; }
        public int FKPEDIDO { get; set; }
        public int FKPLATILLO { get; set; }
        public string PLATILLO { get; set; }
        public decimal PRECIO { get; set; }
        public int CANTIDAD { get; set; }
        public decimal SUBTOTAL { get; set; }
        public string IMAGEN { get; set; }
    }
}
