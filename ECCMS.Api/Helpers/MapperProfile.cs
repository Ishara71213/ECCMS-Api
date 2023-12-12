using AutoMapper;
using ECCMS.Api.Dtos;
using ECCMS.Core.Entities;

namespace ECCMS.Api.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<CityDto, City>().ReverseMap();
        }
       
    }
}
