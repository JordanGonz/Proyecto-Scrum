using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Scrum.Core.Dtos
{
    public class PersonaDto
    {
        [JsonPropertyName("idPersona")]
        public int Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = null!;

        [JsonPropertyName("apellido")]
        public string Apellido { get; set; } = null!;

        [JsonPropertyName("correoElectronico")]
        public string CorreoElectronico { get; set; } = null!;

        [JsonPropertyName("numeroTelefono")]
        public string? NumeroTelefono { get; set; }
    }
}
