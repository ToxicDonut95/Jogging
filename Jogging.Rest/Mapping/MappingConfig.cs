using AutoMapper;
using Jogging.Domain;
using Jogging.Rest.DTO;

namespace Jogging.Rest.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<WeatherForecast, WeatherForecastDTO>().ReverseMap();
        }
    }
}