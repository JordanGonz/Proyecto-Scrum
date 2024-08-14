using Scrum.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Infraestructure.Constracts.Repositories
{
    public interface ILIstaRepositoty
    {
        Task<List<Lista>> ObtenerTodosAsync();
        Task<Lista?> ObtenerPorIdAsync(int idLista);
        Task<bool> CrearAsync(Lista lista);
        Task<bool> ActualizarAsync(Lista lista);
        Task<bool> EliminarAsync(int idLista);
    }
}
