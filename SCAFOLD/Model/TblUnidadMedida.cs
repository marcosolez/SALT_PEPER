using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SCAFOLD.Model
{
    public partial class TblUnidadMedida
    {
        public TblUnidadMedida()
        {
            TblIngrediente = new HashSet<TblIngrediente>();
        }

        public int Pk { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<TblIngrediente> TblIngrediente { get; set; }
    }
}
