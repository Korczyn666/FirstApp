using System.Linq;
using AutoMapper;
using FirstApp.API.Dtos;
using FirstApp.API.Models;

namespace FirstApp.API.helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, opt => 
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => 
                     p.IsMain).Url)).ForMember(dest => dest.Age, opt => 
                     opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserFroDetailedDto>()
            .ForMember(dest => dest.PhotoUrl, opt => 
                 opt.MapFrom(src => src.Photos.FirstOrDefault(p => 
                 p.IsMain).Url)).ForMember(dest => dest.Age, opt => 
                     opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoForDetailedDto>();
            CreateMap<UserForUpdateDto, User>();
        }
    }
}