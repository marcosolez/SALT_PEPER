using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SALT_PEPER.ENTIDADES
{
    public partial class TblUnidadMedida
    {
        public TblUnidadMedida()
        {
            TblIngrediente = new HashSet<TblIngrediente>();
        }

        public int Pk { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        [Display(Name ="Unidad de medida")]
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<TblIngrediente> TblIngrediente { get; set; }
    }
}
