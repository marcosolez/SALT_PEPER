using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SALT_PEPER.Models
{
    public partial class TblIngredientePlatillo
    {
        public int Pk { get; set; }
        public int Fkingrediente { get; set; }
        public int Fkplatillo { get; set; }
        public double Cantidadunidad { get; set; }

        public virtual TblIngrediente FkingredienteNavigation { get; set; }
        public virtual TblPlatilloBebida FkplatilloNavigation { get; set; }
    }
}
