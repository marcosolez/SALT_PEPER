using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SCAFOLD.Model
{
    public partial class TblHorarios
    {
        public int Pk { get; set; }
        public DateTime? Fechamarcacion { get; set; }
        public TimeSpan? Horaentrada { get; set; }
        public TimeSpan? Horasalida { get; set; }
        public bool? Finalizado { get; set; }
        public string Username { get; set; }
    }
}
