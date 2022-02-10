using AutoMapper;
using GestupperwareApi.Dtos.Storages;
using GestupperwareApi.Models;

namespace GestupperwareApi.Profiles
{
    public class StorageProfile : Profile
    {
        public StorageProfile()
        {
            CreateMap<Storage, StorageDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ReverseMap();
        }
    }
}