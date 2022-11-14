using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SALT_PEPER.ENTIDADES.DTOs
{
    public class PlatillosDTO
    {
        public int PK { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string DESCRIPCION { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public decimal? PRECIO { get; set; }
        public string IMAGEN { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int? FKCATEGORIAPLATILLO { get; set; }
        public bool? ESTADO { get; set; }
        public bool TIENEINGREDIENTE { get; set; }
        public IFormFile Files { get; set; }
        public List<IngredinetesDTO> LISTADOINGREDIENTE { get; set; }
    }
}
