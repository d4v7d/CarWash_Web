using System;
using System.Collections.Generic;

namespace PruebaTecnica.API.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            Cita = new HashSet<Citum>();
        }

        public Guid ServicioId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Precio { get; set; }

        public virtual ICollection<Citum> Cita { get; set; }
    }
}
