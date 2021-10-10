
using System;
using System.Collections.Generic;

namespace Obligatorio.Domain.Model
{
    public class Transaccion
    {
        public Usuario UsuarioOrigen { get; set; } = new();
        public Usuario UsuarioDestinatario { get; set; } = new();
        public long IdTransaccion { get; set; }
        public DateTime Fecha { get; set; }
        public string EstadoTransaccion { get; set; }
        public List<Publicacion> PublicacionesOfrecidas { get; set; } = new();
        public List<Publicacion> PublicacionesDeseadas { get; set; } = new();
        public Transaccion TransaccionContraofertada { get; set; } = null;
    }
}
