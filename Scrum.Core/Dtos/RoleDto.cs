using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Scrum.Core.Dtos
{
    public class RoleDto
    {
        [JsonPropertyName("idRol")]
        public int Id { get; set; }

        [JsonPropertyName("nombreRol")]
        public string NombreRol { get; set; } = null!;
    }
}
