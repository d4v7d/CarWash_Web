using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.WEB.Models
{
    public partial class Cita
    {
        public Cita()
        {
        }

        public Guid CitaId { get; set; }
        public string Estado { get; set; } = null!;
        public string ClienteId { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Servicio")]
        public Guid ServicioId { get; set; }

        public AspNetUser? Cliente { get; set; }
        public Servicio? Servicio { get; set; }
    }
}
