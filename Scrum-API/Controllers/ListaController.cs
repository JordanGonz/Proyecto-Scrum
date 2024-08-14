
using Microsoft.AspNetCore.Mvc;
using Scrum.Core.Contracts.Services;
using Scrum.Core.Dtos;
using Scrum.Core.Models.ApiResponse;

namespace Scrum_API.Controllers
{
    [Route("api/lista")]
    [ApiController]
    public class ListaController :BaseApiController<ListaController>
    {
        private readonly IListaService _listaService;

        public ListaController(IListaService listaService)
        {
            _listaService = listaService;
        }

         [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var response = new Response<List<ListaDto>>(true, "OK");
            try
            {
                response.Data = await _listaService.ObtenerTodosLasListaAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener la lista.", null));
            }
        }


    }
}
