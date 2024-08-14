using Scrum.Core.Dtos;
using Scrum.Infraestructure.MainContext;
using AutoMapper;

namespace Scrum.Infraestructure.Mappers
{
    public class ComentariosProfile : Profile
    {
        public ComentariosProfile()
        {
            CreateMap<ComentariosTarea, ComentariosTareaDto>();
            CreateMap<ComentariosTareaDto, ComentariosTarea>();

        }
    }
}
