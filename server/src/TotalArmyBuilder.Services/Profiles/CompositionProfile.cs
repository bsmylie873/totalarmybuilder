using AutoMapper;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Profiles;

public class CompositionProfile : Profile
{
    public CompositionProfile()
    {
        ConfigureDomainToDtoModel();
        ConfigureDtoToDomainModel();
    }

    private void ConfigureDomainToDtoModel()
    {
        CreateMap<Composition, CompositionDto>()
        .ForMember(d=>d.Units, o=> o.MapFrom(x=> x.CompositionUnits.Select(y=> y.Unit)))
        .ForMember(d=>d.Units2, o=> o.MapFrom(x=> x.CompositionUnits2.Select(y=> y.Unit)));
    }

    private void ConfigureDtoToDomainModel()
    {
        CreateMap<CompositionDto, Composition>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.CompositionUnits, o=> o.MapFrom(x=>x.Units))
            .ForMember(d => d.CompositionUnits2, o=> o.MapFrom(x=>x.Units2));
        CreateMap<CompositionDto, AccountComposition>() 
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember( d=> d.CompositionId, o=> o.MapFrom(x=> x.Id));
    }
}