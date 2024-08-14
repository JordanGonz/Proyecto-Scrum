using Scrum.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Core.Contracts.Services
{
    public interface ITableroService
    {
        Task<List<TableroDto>> ObtenerTodosLasListaAsync();
        Task<TableroDto> ObtenerListaPorIdAsync(int idTablero);
        Task<bool> CrearListaAsync(TableroDto tableroDto);
        Task<bool> ActualizarListaAsync(int idTablero, TableroDto tableroDto);
        Task<bool> EliminarListaAsync(int idTablero);
    }
}
