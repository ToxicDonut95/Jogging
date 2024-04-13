using AutoMapper;
using Jogging.Domain.Helpers;
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
            CreateMap<SchoolDOM, SchoolDTO>().ReverseMap();
            CreateMap<School, SchoolDOM>().ReverseMap();
            CreateMap<AddressDOM, AddressDTO>().ReverseMap();
            CreateMap<Address, AddressDOM>().ReverseMap();
            CreateMap<Task<IEnumerable<Person>>, Task<IEnumerable<PersonDOM>>>().ReverseMap();
            CreateMap<Task<IEnumerable<PersonDOM>>, IEnumerable<PersonDTO>>().ReverseMap();
            CreateMap<Competition, CompetitionDOM>().ReverseMap();
            CreateMap<CompetitionDOM, CompetitionDTO>().ReverseMap();
            CreateMap<Registration, RegistrationDTO>().ReverseMap();
            CreateMap<Task<Registration>, RegistrationDTO>().ReverseMap();
        }
    }
}