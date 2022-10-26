using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SALT_PEPER.Models
{
    public partial class TblCategoriaPlatillo
    {
        public TblCategoriaPlatillo()
        {
            TblPlatilloBebida = new HashSet<TblPlatilloBebida>();
        }

        public int Pk { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<TblPlatilloBebida> TblPlatilloBebida { get; set; }
    }
}
