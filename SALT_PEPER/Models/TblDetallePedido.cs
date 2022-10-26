using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SALT_PEPER.Models
{
    public partial class TblDetallePedido
    {
        public int Pk { get; set; }
        public int Fkpedido { get; set; }
        public int Fkplatillobebida { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }

        public virtual TblPedido FkpedidoNavigation { get; set; }
        public virtual TblPlatilloBebida FkplatillobebidaNavigation { get; set; }
    }
}
