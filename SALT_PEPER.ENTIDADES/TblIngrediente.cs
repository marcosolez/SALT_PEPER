using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SALT_PEPER.ENTIDADES
{
    public partial class TblIngrediente
    {
        public TblIngrediente()
        {
            TblDetalleCompra = new HashSet<TblDetalleCompra>();
            TblIngredientePlatillo = new HashSet<TblIngredientePlatillo>();
            TblInventario = new HashSet<TblInventario>();
        }

        public int Pk { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public int Fkunidadmedida { get; set; }
        public double Cantidadporunidad { get; set; }
        public double Minimostock { get; set; }

        public virtual TblUnidadMedida FkunidadmedidaNavigation { get; set; }
        public virtual ICollection<TblDetalleCompra> TblDetalleCompra { get; set; }
        public virtual ICollection<TblIngredientePlatillo> TblIngredientePlatillo { get; set; }
        public virtual ICollection<TblInventario> TblInventario { get; set; }
    }
}
