using Scrum.Core.Dtos;
using System;
using System.Collections.Generic;


namespace Scrum.Core.Contracts.Services
{
    public interface IComentariosService
    {
        Task<List<ComentariosTareaDto>> ObtenerTodosLoComentariosAsync();
        Task<ComentariosTareaDto> ObtenerComentariosPorIdAsync(int idComentario);
        Task<bool> CrearComentariosAsync(ComentariosTareaDto comentariosTareaDto);
        Task<bool> ActualizarComentariosAsync(int idComentario, ComentariosTareaDto comentariosTareaDto);
        Task<bool> EliminarComentariosAsync(int idComentario);
    }
}
