using AutoMapper;
using TotalArmyBuilder.Api.Extensions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Api.Profiles;

public class UnitProfile : Profile
{
    public UnitProfile()
    {
        ConfigureDtoToViewModel();
        ConfigureCreateModelToDto();
    }

    private void ConfigureDtoToViewModel()
    {
        CreateMap<UnitDto, UnitViewModel>().IgnoreAllNull();
        CreateMap<UnitDto, UnitDetailViewModel>().IgnoreAllNull();
    }

    private void ConfigureCreateModelToDto()
    {
        CreateMap<UnitViewModel,UnitDto>().IgnoreAllNull();
    }
}