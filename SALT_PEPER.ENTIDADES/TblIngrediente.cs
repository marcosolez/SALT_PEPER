using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        [Required(ErrorMessage = "La unidad es requerida")]
        public int Fkunidadmedida { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Display(Name ="Cantidad por unidad")]
        public double Cantidadporunidad { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Display(Name = "Stok mínimo")]
        public double Minimostock { get; set; }

        public virtual TblUnidadMedida FkunidadmedidaNavigation { get; set; }
        public virtual ICollection<TblDetalleCompra> TblDetalleCompra { get; set; }
        public virtual ICollection<TblIngredientePlatillo> TblIngredientePlatillo { get; set; }
        public virtual ICollection<TblInventario> TblInventario { get; set; }
    }
}
