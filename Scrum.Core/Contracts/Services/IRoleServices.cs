using Scrum.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Core.Contracts.Services
{
    public interface IRoleServices
    {
        Task<List<RoleDto>> ObtenerTodosLosRolesAsync();
        Task<RoleDto> ObtenerRolPorIdAsync(int idRol);
        Task<bool> CrearRolAsync(RoleDto roleDto);
        Task<bool> ActualizarRolAsync(int idRol, RoleDto roleDto);
        Task<bool> EliminarRolAsync(int idRol);
    }
}
