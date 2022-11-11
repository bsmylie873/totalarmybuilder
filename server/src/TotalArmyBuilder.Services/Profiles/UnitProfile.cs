using AutoMapper;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Services;

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
    }
    
    private void ConfigureDtoToDomainModel()
    {
        CreateMap<UnitDto, Unit>()
            .ForMember(d => d.Id, o => o.Ignore());
    }
}