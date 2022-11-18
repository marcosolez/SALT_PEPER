using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SALT_PEPER.ENTIDADES.DTOs
{
    public class CompraDTO
    {
        public int? PK { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string NUMFACTURA { get; set; }
        public DateTime? FECHACOMPRA { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public int FKPROVEEDOR { get; set; }
        public string USERNAME { get; set; }
        public bool? ESTADO { get; set; }
        public int? FKINGREDIENTE { get; set; }
        public int? CANTIDAD { get; set; }
        public decimal? PRECIO { get; set; }
        public List<DetalleCompraDTO> DETALLECOMPRADTO { get; set; }
    }

    public class DetalleCompraDTO
    {
        public int PK { get; set; }
        public int FKCOMPRA { get; set; }
        public int FKINGREDIENTE { get; set; }
        public int CANTIDADUNIDAD { get; set; }
        public bool ESTADO { get; set; }
        public decimal PRECIO { get; set; }
    }
}
