using Scrum.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Infraestructure.Constracts.Repositories
{
    public interface IComentariosRepository
    {
        Task<List<ComentariosTarea>> ObtenerTodosAsync();
        Task<ComentariosTarea?> ObtenerPorIdAsync(int idComentario);
        Task<bool> CrearAsync(ComentariosTarea comentario);
        Task<bool> ActualizarAsync(ComentariosTarea comentario);
        Task<bool> EliminarAsync(int idComentario);
    }
}
