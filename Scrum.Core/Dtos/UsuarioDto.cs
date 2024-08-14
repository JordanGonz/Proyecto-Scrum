using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Scrum.Core.Dtos
{
    public class UsuarioDto
    {
        [JsonPropertyName("idUsuario")]
        public int Id { get; set; }

        [JsonPropertyName("nombreUsuario")]
        public string NombreUsuario { get; set; } = null!;

        [JsonPropertyName("contraseña")]
        public string ContraseñaHash { get; set; } = null!;

        [JsonPropertyName("idRol")]
        public int IdRol { get; set; }

        [JsonPropertyName("idPersona")]
        public int IdPersona { get; set; }
    }
}
