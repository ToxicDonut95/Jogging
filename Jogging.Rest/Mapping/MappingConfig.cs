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
            CreateMap<PersonResponseDOM, PersonResponseDTO>().ReverseMap();
            CreateMap<Person, PersonResponseDOM>().ReverseMap();

            CreateMap<SchoolResponseDOM, SchoolRequestDTO>().ReverseMap();
            CreateMap<School, SchoolResponseDOM>().ReverseMap();

            CreateMap<AddressResponseDOM, AddressResponseDTO>().ReverseMap();
            CreateMap<Address, AddressResponseDOM>().ReverseMap();

            CreateMap<Task<IEnumerable<Person>>, Task<IEnumerable<PersonResponseDOM>>>().ReverseMap();
            CreateMap<Task<IEnumerable<PersonResponseDOM>>, IEnumerable<PersonResponseDTO>>().ReverseMap();
            CreateMap<Person, PersonRequestDOM>().ReverseMap();
            CreateMap<PersonRequestDOM, PersonRequestDTO>().ReverseMap();

            CreateMap<Competition, CompetitionResponseDOM>().ReverseMap();
            CreateMap<CompetitionResponseDOM, CompetitionResponseDTO>().ReverseMap();
            CreateMap<Competition, CompetitionRequestDOM>().ReverseMap();
            CreateMap<CompetitionRequestDOM, CompetitionRequestDTO>().ReverseMap();

            CreateMap<Registration, RegistrationResponseDTO>().ReverseMap();
            CreateMap<Task<Registration>, RegistrationResponseDTO>().ReverseMap();
        }
    }
}