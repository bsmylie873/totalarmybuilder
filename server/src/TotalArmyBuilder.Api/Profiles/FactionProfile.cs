using AutoMapper;
using TotalArmyBuilder.Api.ViewModels.Factions;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Api.Profiles;

public class FactionProfile : Profile
{
    public FactionProfile()
    {
        ConfigureDTOToViewModel();
    }

    private void ConfigureDTOToViewModel()
    {
        CreateMap<FactionDto, FactionViewModel>().ForAllMembers(
            opts => 
                opts.Condition((src, dest, srcMember) => srcMember != null));
    }

    private void ConfigureCreateModelToDTO()
    {
    } 
}