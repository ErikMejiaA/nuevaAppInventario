
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pais, PaisDto>().ReverseMap();
        CreateMap<Estado, EstadoDto>().ReverseMap();
        
    }
}
