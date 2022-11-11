using AutoMapper;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Services;

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
        CreateMap<Composition, CompositionDto>();
    }
    
    private void ConfigureDtoToDomainModel()
    {
        CreateMap<CompositionDto, Composition>()
            .ForMember(d => d.Id, o => o.Ignore());
    }
}