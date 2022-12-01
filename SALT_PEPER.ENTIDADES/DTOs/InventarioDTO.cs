using System;
using System.Collections.Generic;
using System.Text;

namespace SALT_PEPER.ENTIDADES.DTOs
{
    public class InventarioDTO
    {
        public int FKINGREDIENTE { get; set; }
        public string INGREDIENTE { get; set; }
        public double STOCK { get; set; }
        public string UNIDADMEDIDA { get; set; }
        public double STOCKMINIMO { get; set; }

        public DateTime FECHAACTUALIZACION { get; set; }
    }
}
