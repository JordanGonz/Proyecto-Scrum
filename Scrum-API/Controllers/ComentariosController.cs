using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Scrum.Core.Contracts.Services;
using Scrum.Core.Dtos;
using Scrum.Core.Models.ApiResponse;
using Microsoft.Extensions.Logging;

namespace Scrum_API.Controllers;

    [Route("api/comentarios")]
    [ApiController]
    public class ComentariosController : BaseApiController<ComentariosController>
{
        private readonly IComentariosService _comentariosTareaService;

        public ComentariosController(IComentariosService comentariosTareaService)
        {
            _comentariosTareaService = comentariosTareaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var response = new Response<List<ComentariosTareaDto>>(true, "OK");
            try
            {
                response.Data = await _comentariosTareaService.ObtenerTodosLoComentariosAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener la lista de comentarios.", null));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var response = new Response<ComentariosTareaDto>(true, "OK");
            try
            {
                var comentario = await _comentariosTareaService.ObtenerComentariosPorIdAsync(id);
                if (comentario == null)
                {
                    return NotFound(new ErrorResponse<ComentariosTareaDto>
                    {
                        Success = false,
                        Message = "Comentario no encontrado."
                    });
                }
                return Ok(new SuccessResponse<ComentariosTareaDto>
                {
                    Success = true,
                    Message = "OK",
                    Data = comentario
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                return Conflict(new ErrorResponse<ComentariosTareaDto>
                {
                    Success = false,
                    Message = "Lo sentimos, no se pudo obtener el comentario por ID.",
                    ErrorCode = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ComentariosTareaDto comentarioDto)
        {
            var response = new Response<string>(true, "OK");
            try
            {
                if (comentarioDto == null)
                {
                    response.Update(false, "Datos del comentario no proporcionados.", "");
                    return BadRequest(response);
                }

                var success = await _comentariosTareaService.CrearComentariosAsync(comentarioDto);

                if (!success)
                {
                    response.Message = "Lo sentimos, no se pudo crear el comentario.";
                    return Conflict(response);
                }

                return Created(nameof(ObtenerPorId), response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                return Conflict(response.Update(false, "Lo sentimos, no se pudo agregar el comentario.", null));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ComentariosTareaDto comentarioDto)
        {
            var response = new Response<ComentariosTareaDto>(true, "OK");
            try
            {
                var comentarioExistente = await _comentariosTareaService.ObtenerComentariosPorIdAsync(id);
                if (comentarioExistente == null)
                {
                    response.Update(false, "Comentario no encontrado.", null);
                    return NotFound(response);
                }

                var success = await _comentariosTareaService.ActualizarComentariosAsync(id, comentarioDto);
                response.Message = success ? "Comentario actualizado con éxito"
                    : $"Lo sentimos, no se pudo actualizar el comentario con id {id}";
                return Ok(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                return Conflict(response.Update(false, "Lo sentimos, no se pudo actualizar el comentario.", null));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new Response<string>(true, "OK");
            try
            {
                var comentarioExistente = await _comentariosTareaService.ObtenerComentariosPorIdAsync(id);
                if (comentarioExistente == null)
                {
                    response.Update(false, "Comentario no encontrado.", null);
                    return NotFound(response);
                }

                var success = await _comentariosTareaService.EliminarComentariosAsync(id);
                response.Message = success ? "Comentario eliminado con éxito"
                    : $"Lo sentimos, no se pudo eliminar el comentario con id {id}";
                return Ok(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                return Conflict(response.Update(false, "Lo sentimos, no se pudo eliminar el comentario.", null));
            }
        }
    }

