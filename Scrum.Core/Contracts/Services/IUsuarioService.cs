using Scrum.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Core.Contracts.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDto>> ObtenerTodosLosUsuriosAsync();
        Task<UsuarioDto> ObtenerUsuariosPorIdAsync(int idUsuario);
        Task<bool> CrearUsuariosAsync(UsuarioDto usuarioDto);
        Task<bool> ActualizarUsuarioAsync(int idUsuario, UsuarioDto usuarioDto);
        Task<bool> EliminarUsuarioAsync(int idUsuario);
    }
}
