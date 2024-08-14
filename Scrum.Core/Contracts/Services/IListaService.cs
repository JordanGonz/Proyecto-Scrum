using Scrum.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Core.Contracts.Services
{
    public interface IListaService
    {
        Task<List<ListaDto>> ObtenerTodosLasListaAsync();
        Task<ListaDto> ObtenerListaPorIdAsync(int idLista);
        Task<bool> CrearListaAsync(ListaDto listaDto);
        Task<bool> ActualizarListaAsync(int idLista, ListaDto listaDto);
        Task<bool> EliminarListaAsync(int idLista);
    }
}
