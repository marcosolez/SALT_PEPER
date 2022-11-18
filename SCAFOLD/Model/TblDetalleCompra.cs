using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SCAFOLD.Model
{
    public partial class TblDetalleCompra
    {
        public int Pk { get; set; }
        public int Fkcompra { get; set; }
        public int Fkingrediente { get; set; }
        public int Cantidadunidad { get; set; }
        public bool Estado { get; set; }
        public decimal Precio { get; set; }

        public virtual TblCompra FkcompraNavigation { get; set; }
        public virtual TblIngrediente FkingredienteNavigation { get; set; }
    }
}
