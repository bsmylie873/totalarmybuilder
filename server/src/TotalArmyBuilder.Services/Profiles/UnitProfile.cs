using AutoMapper;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Profiles;

public class UnitProfile : Profile
{
    public UnitProfile()
    {
        ConfigureDomainToDtoModel();
        ConfigureDtoToDomainModel();
    }

    private void ConfigureDomainToDtoModel()
    {
        CreateMap<Unit, UnitDto>();

        CreateMap<LordUnit, UnitDto>()
            .ForMember(d => d.Id,
                o => o.MapFrom(src => src.Unit.Id))
            .ForMember(d => d.Name,
                o => o.MapFrom(src => src.Unit.Name))
            .ForMember(d => d.Cost,
                o => o.MapFrom(src => src.Unit.Cost))
            .ForMember(d => d.AvatarId,
                o => o.MapFrom(src => src.Unit.AvatarId));

        CreateMap<HeroUnit, UnitDto>()
            .ForMember(d => d.Id,
                o => o.MapFrom(src => src.Unit.Id))
            .ForMember(d => d.Name,
                o => o.MapFrom(src => src.Unit.Name))
            .ForMember(d => d.Cost,
                o => o.MapFrom(src => src.Unit.Cost))
            .ForMember(d => d.AvatarId,
                o => o.MapFrom(src => src.Unit.AvatarId));
    }

    private void ConfigureDtoToDomainModel()
    {
        CreateMap<UnitDto, Unit>();
        CreateMap<UnitDto, CompositionUnit>() 
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember( d=> d.UnitId, o=> o.MapFrom(x=> x.Id));
    }
}