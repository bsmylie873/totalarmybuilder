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
        CreateMap<Unit, UnitDto>().ForAllMembers(
            opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null));

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
        CreateMap<UnitDto, Unit>().ForAllMembers(
            opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}