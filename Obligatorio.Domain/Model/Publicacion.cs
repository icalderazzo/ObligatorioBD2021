
using System;

namespace Obligatorio.Domain.Model
{
    public class Publicacion
    {
        public long IdPublicacion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Usuario Propietario { get; set; }
        public Articulo Articulo { get; set; }
    }
}
