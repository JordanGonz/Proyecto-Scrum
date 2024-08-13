using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Scrum.Core.Dtos
{
    public class ComentariosTareaDto
    {
        [JsonPropertyName("idComentario")]
        public int Id { get; set; }

        [JsonPropertyName("idTarea")]
        public int IdTarea { get; set; }

        [JsonPropertyName("comentario")]
        public string Comentario { get; set; } = null!;

        [JsonPropertyName("idUsuarioCreador")]
        public int IdUsuarioCreador { get; set; }

        [JsonPropertyName("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }

    }
}
