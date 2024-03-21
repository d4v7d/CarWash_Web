using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PruebaTecnica.WEB.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            Cita = new HashSet<Cita>();
        }

        public Guid ServicioId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;

        [Required]
        [StringLength(500)]
        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue)]
        public int Precio { get; set; }

        public ICollection<Cita> Cita { get; set; }
    }
}
