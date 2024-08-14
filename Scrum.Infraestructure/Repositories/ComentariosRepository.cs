using Scrum.Infraestructure.Constracts.Repositories;
using Scrum.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Scrum.Core.Constants;

namespace Scrum.Infraestructure.Repositories
{
    public class ComentariosRepository : IComentariosRepository
    {
        private readonly ScrumManagementContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ComentariosRepository(ScrumManagementContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<ComentariosTarea>> ObtenerTodosAsync()
        {
            return await _context.ComentariosTareas
                .Where(a => a.Estado == ScrumConstants.ESTADO_ACTIVO)
                .ToListAsync();
        }

        public async Task<ComentariosTarea?> ObtenerPorIdAsync(int idComentario)
        {
            return await _context.ComentariosTareas.FindAsync(idComentario);
        }

        public async Task<bool> CrearAsync(ComentariosTarea comentario)
        {
            _context.ComentariosTareas.Add(comentario);
            int result= await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> ActualizarAsync(ComentariosTarea comentario)
        {
            _context.Entry(comentario).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int idComentario)
        {
            var comentario = await _context.ComentariosTareas.FindAsync(idComentario);

            if (comentario == null)
            {
                return false;
            }

            _context.ComentariosTareas.Remove(comentario);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
