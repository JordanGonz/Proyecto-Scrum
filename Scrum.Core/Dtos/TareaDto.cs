using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Scrum.Core.Dtos
{
    public  class TareaDto
    {
        [JsonPropertyName("idTarea")]
        public int Id { get; set; }

        [JsonPropertyName("titulo")]
        public string Titulo { get; set; } = null!;

        [JsonPropertyName("descripcion")]
        public string? Descripcion { get; set; }

        [JsonPropertyName("idLista")]
        public int IdLista { get; set; }

        [JsonPropertyName("idUsuarioAsignado")]
        public int? IdUsuarioAsignado { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; } = null!;

        [JsonPropertyName("prioridad")]
        public string? Prioridad { get; set; }

        [JsonPropertyName("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [JsonPropertyName("fechaVencimiento")]
        public DateTime? FechaVencimiento { get; set; }
    }
}
