using AutoMapper;
using GestupperwareApi.Dtos;
using GestupperwareApi.Models;

namespace GestupperwareApi.Profiles
{
    public class TupperwareProfile : Profile
    {
        public TupperwareProfile()
        {
            CreateMap<Tupperware, TupperwareDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(
                    dest => dest.Quantity,
                    opt => opt.MapFrom(src => $"{src.Quantity}")
                )
                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => $"{src.Price}")
                )
                .ForMember(
                    dest => dest.Color,
                    opt => opt.MapFrom(src => $"{src.Color}")
                );
        }
    }
}