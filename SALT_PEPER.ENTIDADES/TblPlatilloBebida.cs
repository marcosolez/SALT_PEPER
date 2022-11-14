using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SALT_PEPER.ENTIDADES
{
    public partial class TblPlatilloBebida
    {
        public TblPlatilloBebida()
        {
            TblDetallePedido = new HashSet<TblDetallePedido>();
            TblIngredientePlatillo = new HashSet<TblIngredientePlatillo>();
        }

        public int Pk { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public decimal? Precio { get; set; }
        public string Imagen { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int? Fkcategoriaplatillo { get; set; }
        public bool? Estado { get; set; }

        public virtual TblCategoriaPlatillo FkcategoriaplatilloNavigation { get; set; }
        public virtual ICollection<TblDetallePedido> TblDetallePedido { get; set; }
        public virtual ICollection<TblIngredientePlatillo> TblIngredientePlatillo { get; set; }
    }
}
