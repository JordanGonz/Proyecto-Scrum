using Microsoft.AspNetCore.Http;
using Scrum.Infraestructure.Constracts.Repositories;
using Scrum.Infraestructure.MainContext;
using System.Data.Entity;

namespace Scrum.Infraestructure.Repositories
{
    public class ListaRepository : ILIstaRepositoty
    {
        private readonly ScrumManagementContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ListaRepository(ScrumManagementContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<List<Lista>> ObtenerTodosAsync()
        {
            return await _context.Listas.ToListAsync();
        }


        public async Task<Lista?> ObtenerPorIdAsync(int idLista)
        {
            return await _context.Listas.FindAsync(idLista);
        }

        public async Task<bool> CrearAsync(Lista lista)
        {
            _context.Listas.Add(lista);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }


        public async Task<bool> ActualizarAsync(Lista lista)
        {
            return await _context.SaveChangesAsync() >0;
        }

        public async Task<bool> EliminarAsync(int idLista)
        {
            var lista = await _context.Listas.FindAsync(idLista);

            if (lista == null)
            {
                return false;
            }

            _context.Listas.Remove(lista);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
