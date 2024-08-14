using AutoMapper;
using Scrum.Core.Contracts.Services;
using Scrum.Core.Dtos;
using Scrum.Core.Constants;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Scrum.Infraestructure.Constracts.Repositories;
using Scrum.Infraestructure.MainContext;

public class ComentariosTareaService : IComentariosService
{
    private readonly IComentariosRepository _comentariosRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ComentariosTareaService(IComentariosRepository comentariosRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _comentariosRepository = comentariosRepository;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<ComentariosTareaDto>> ObtenerTodosLoComentariosAsync()
    {
        try
        {
            var comentarios = await _comentariosRepository.ObtenerTodosAsync();
            return _mapper.Map<List<ComentariosTareaDto>>(comentarios);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener todos los comentarios.", ex);
        }
    }

    public async Task<ComentariosTareaDto> ObtenerComentariosPorIdAsync(int idComentario)
    {
        var comentario = await _comentariosRepository.ObtenerPorIdAsync(idComentario);
        return _mapper.Map<ComentariosTareaDto>(comentario);
    }

    public async Task<bool> CrearComentariosAsync(ComentariosTareaDto comentarioDto)
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
        {
            throw new Exception("Usuario no autenticado o ID de usuario inválido.");
        }

        var comentario = _mapper.Map<ComentariosTarea>(comentarioDto);
        comentario.IdUsuarioCreador = userId;
        comentario.FechaCreacion = DateTime.Now;
        comentario.Estado = ScrumConstants.ESTADO_ACTIVO;

        return await _comentariosRepository.CrearAsync(comentario);
    }

    public async Task<bool> ActualizarComentariosAsync(int idComentario, ComentariosTareaDto comentarioDto)
    {
     
        var comentarioExistente = await _comentariosRepository.ObtenerPorIdAsync(idComentario);

     
        if (comentarioExistente == null)
        {
            return false;
        }

   
        _mapper.Map(comentarioDto, comentarioExistente);
        await _comentariosRepository.ActualizarAsync(comentarioExistente);
        return true;
    }



    public async Task<bool> EliminarComentariosAsync(int idComentario)
    {
       
        var comentarioExistente = await _comentariosRepository.ObtenerPorIdAsync(idComentario);

        if (comentarioExistente == null)
        {
            return false;
        }

        return await _comentariosRepository.EliminarAsync(idComentario);
    }

}
