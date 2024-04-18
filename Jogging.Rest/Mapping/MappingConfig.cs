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
            CreateMap<PersonResponseDOM, PersonResponseDTO>().ReverseMap();
            CreateMap<Person, PersonResponseDOM>().ReverseMap();
            CreateMap<PersonRequestDOM, PersonRequestDTO>().ReverseMap();
            CreateMap<Person, PersonRequestDOM>().ReverseMap();
            
            CreateMap<School, SchoolResponseDOM>().ReverseMap();
            CreateMap<SchoolResponseDOM, SchoolResponseDTO>().ReverseMap();             
            CreateMap<School, SchoolRequestDOM>().ReverseMap();
            CreateMap<SchoolRequestDOM, SchoolRequestDTO>().ReverseMap(); 
            
            CreateMap<Address, AddressResponseDOM>().ReverseMap();
            CreateMap<AddressResponseDOM, AddressResponseDTO>().ReverseMap();            
            CreateMap<Address, AddressRequestDOM>().ReverseMap();
            CreateMap<AddressRequestDOM, AddressRequestDTO>().ReverseMap();
            
            CreateMap<Task<IEnumerable<Person>>, Task<IEnumerable<PersonResponseDOM>>>().ReverseMap();
            CreateMap<Task<IEnumerable<PersonResponseDOM>>, IEnumerable<PersonResponseDTO>>().ReverseMap();
            
            CreateMap<Competition, CompetitionResponseDOM>().ReverseMap();
            CreateMap<CompetitionResponseDOM, CompetitionResponseDTO>().ReverseMap();            
            CreateMap<Competition, CompetitionRequestDOM>().ReverseMap();
            CreateMap<CompetitionRequestDOM, CompetitionRequestDTO>().ReverseMap();   
            
            CreateMap<CompetitionPerCategory, CompetitionPerCategoryResponseDOM>().ReverseMap();
            CreateMap<CompetitionPerCategoryResponseDOM, CompetitionPerCategoryResponseDTO>().ReverseMap();            
            CreateMap<CompetitionPerCategory, CompetitionPerCategoryRequestDOM>().ReverseMap();
            CreateMap<CompetitionPerCategoryRequestDOM, CompetitionPerCategoryRequestDTO>().ReverseMap();        
            
            CreateMap<AgeCategory, AgeCategoryResponseDOM>().ReverseMap();
            CreateMap<AgeCategoryResponseDOM, AgeCategoryResponseDTO>().ReverseMap();            
            CreateMap<AgeCategory, AgeCategoryRequestDOM>().ReverseMap();
            CreateMap<AgeCategoryRequestDOM, AgeCategoryRequestDTO>().ReverseMap();   
            
            CreateMap<Registration, RegistrationResponseDOM>().ReverseMap();
            CreateMap<RegistrationResponseDOM, RegistrationResponseDTO>().ReverseMap();              
            CreateMap<Registration, RegistrationRequestDOM>().ReverseMap();
            CreateMap<RegistrationRequestDOM, RegistrationRequestDTO>().ReverseMap();    
            
            CreateMap<Registration, RegistrationResponseDTO>().ReverseMap();
            CreateMap<Task<Registration>, RegistrationResponseDTO>().ReverseMap();
        }
    }
}