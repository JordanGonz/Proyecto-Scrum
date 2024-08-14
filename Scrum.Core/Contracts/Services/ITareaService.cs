using Scrum.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Core.Contracts.Services
{
    public interface ITareaService
    {
        Task<List<TareaDto>> ObtenerTodasLasTareasAsync();
        Task<TareaDto> ObtenerTareasPorIdAsync(int idTarea);
        Task<bool> CrearTareasAsync(TareaDto tareaDto);
        Task<bool> ActualizarTareasAsync(int idTarea, TareaDto tareaDto);
        Task<bool> EliminarTareasAsync(int idTarea);
    }
}
