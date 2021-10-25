using System.Collections.Generic;

namespace Obligatorio.Domain.Model
{
    public class Usuario
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public int Telefono { get; set; }
    }
}
