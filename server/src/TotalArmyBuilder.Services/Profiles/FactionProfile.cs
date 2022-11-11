using AutoMapper;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Services;

namespace TotalArmyBuilder.Service.Profiles;

public class FactionProfile : Profile
{
    public FactionProfile()
    {
        ConfigureDomainToDtoModel();
        ConfigureDtoToDomainModel();
    }

    private void ConfigureDomainToDtoModel()
    {
        CreateMap<Faction, FactionDto>();
    }
    
    private void ConfigureDtoToDomainModel()
    {
        CreateMap<FactionDto, Faction>()
            .ForMember(d => d.Id, o => o.Ignore());
    }
}