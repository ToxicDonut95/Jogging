using AutoMapper;
using Jogging.Domain.Models;
using Jogging.Infrastructure.Models;
using Jogging.Rest.DTOs;

namespace Jogging.Rest.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<PersonDOM, PersonDTO>().ReverseMap();
            CreateMap<Person, PersonDOM>().ReverseMap();
        }
    }
}