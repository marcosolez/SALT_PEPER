using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SCAFOLD.Model
{
    public partial class TblPedido
    {
        public TblPedido()
        {
            TblDetallePedido = new HashSet<TblDetallePedido>();
        }

        public int Pk { get; set; }
        public DateTime Fechapedido { get; set; }
        public string Nombrecliente { get; set; }
        public bool Anulado { get; set; }
        public string Username { get; set; }
        public string Estadoorden { get; set; }

        public virtual ICollection<TblDetallePedido> TblDetallePedido { get; set; }
    }
}
