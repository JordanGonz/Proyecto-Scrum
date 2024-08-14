using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Scrum.Core.Dtos
{
    public class ListaDto
    {
        [JsonPropertyName("idLista")]
        public int Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = null!;

        [JsonPropertyName("idTablero")]
        public int IdTablero { get; set; }

        [JsonPropertyName("orden")]
        public int Orden { get; set; }

    }
}
