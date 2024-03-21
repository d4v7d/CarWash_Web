using System;
using System.Collections.Generic;

namespace PruebaTecnica.API.Models
{
    public partial class Citum
    {
        public Guid CitaId { get; set; }
        public string Estado { get; set; } = null!;
        public string ClienteId { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public Guid ServicioId { get; set; }

        public virtual AspNetUser? Cliente { get; set; }
        public virtual Servicio? Servicio { get; set; }
    }
}
