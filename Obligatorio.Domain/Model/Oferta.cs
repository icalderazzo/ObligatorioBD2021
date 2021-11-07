
using System;
using System.Collections.Generic;

namespace Obligatorio.Domain.Model
{
    public class Oferta
    {
        public long IdOferta { get; set; }
        public DateTime Fecha { get; set; }
        public EnumOfertas.EstadoOferta Estado { get; set; }
        public Usuario UsuarioEmisor { get; set; } = new();
        public Usuario UsuarioDestinatario { get; set; } = new();
        /// <summary>
        /// Publicaciones del emisor
        /// </summary>
        public List<Publicacion> PublicacionesOfrecidas { get; set; } = new();
        /// <summary>
        /// Publicaciones del destinatario
        /// </summary>
        public List<Publicacion> PublicacionesDeseadas { get; set; } = new();
        public Oferta TransaccionContraofertada { get; set; } = null;
    }
}
