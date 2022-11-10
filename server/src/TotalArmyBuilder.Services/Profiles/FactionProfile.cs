using AutoMapper;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Services;

namespace TotalArmyBuilder.Service.Profiles;

public class FactionProfile : Profile
{
    public FactionProfile()
    {
        ConfigureDomainToViewModel();
    }

    private void ConfigureDomainToViewModel()
    {
        CreateMap<Faction, FactionDTO>()
            .ForMember(d => d.Id, o => o.Ignore());
    }
}