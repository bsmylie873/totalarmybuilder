using AutoMapper;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Api.Profiles;

public class UnitProfile : Profile
{
    public UnitProfile()
    {
        ConfigureDTOToViewModel();
    }

    private void ConfigureDTOToViewModel()
    {
        CreateMap<UnitDto, UnitViewModel>().ForAllMembers(
            opts => 
                opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<UnitDto, UnitDetailViewModel>().ForAllMembers(
            opts => 
                opts.Condition((src, dest, srcMember) => srcMember != null));
    }

    private void ConfigureCreateModelToDTO()
    {
    } 
}