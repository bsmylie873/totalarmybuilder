using AutoMapper;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Services;

namespace TotalArmyBuilder.Service.Profiles;

public class UnitProfile : Profile
{
    public UnitProfile()
    {
        ConfigureDomainToViewModel();
    }

    private void ConfigureDomainToViewModel()
    {
        CreateMap<Unit, UnitDTO>()
            .ForMember(d => d.Id, o => o.Ignore());
    }
}