using Scrum.Core.Dtos;
using Scrum.Infraestructure.MainContext;
using AutoMapper;

namespace Scrum.Infraestructure.Mappers
{
    public class ListaProfile: Profile
    {
        public ListaProfile() 
        {
            CreateMap<Lista, ListaDto>();
            CreateMap<ListaDto, Lista>();
        }
      
    }
}
