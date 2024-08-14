using Scrum.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Core.Contracts.Services
{
    public interface IPersonaService
    {
        Task<List<PersonaDto>> ObtenerTodosPersonasAsync();
        Task<PersonaDto> ObtenerPersonasPorIdAsync(int idPersona);
        Task<bool> CrearPersonasAsync(PersonaDto equipoCreacionDto);
        Task<bool> ActualizarPersonasAsync(int idPersona, PersonaDto personaDto);
        Task<bool> EliminarPersonasAsync(int idPersona);
    }
}
