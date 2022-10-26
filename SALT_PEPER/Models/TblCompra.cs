using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SALT_PEPER.Models
{
    public partial class TblCompra
    {
        public TblCompra()
        {
            TblDetalleCompra = new HashSet<TblDetalleCompra>();
        }

        public int Pk { get; set; }
        public string Numfactura { get; set; }
        public int Fechacompra { get; set; }
        public int Fkproveedor { get; set; }
        public string Username { get; set; }
        public bool Estado { get; set; }

        public virtual TblProveedor FechacompraNavigation { get; set; }
        public virtual ICollection<TblDetalleCompra> TblDetalleCompra { get; set; }
    }
}
