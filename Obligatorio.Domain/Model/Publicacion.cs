
using System;

namespace Obligatorio.Domain.Model
{
    public class Publicacion
    {
        public Producto Producto { get; set; }
        public int CiUsuario { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}
