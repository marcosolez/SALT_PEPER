using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SALT_PEPER.ENTIDADES
{
    public partial class TblProveedor
    {
        public TblProveedor()
        {
            TblCompra = new HashSet<TblCompra>();
        }

        public int Pk { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int? Telefono { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Direccion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<TblCompra> TblCompra { get; set; }
    }
}
