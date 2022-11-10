using AutoMapper;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Services;

namespace TotalArmyBuilder.Service.Profiles;

public class CompositionProfile : Profile
{
    public CompositionProfile()
    {
        ConfigureDomainToViewModel();
    }

    private void ConfigureDomainToViewModel()
    {
        CreateMap<Composition, CompositionDTO>()
            .ForMember(d => d.Id, o => o.Ignore());
    }
}