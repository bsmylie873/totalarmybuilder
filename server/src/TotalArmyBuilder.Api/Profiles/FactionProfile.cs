using AutoMapper;
using TotalArmyBuilder.Api.Extensions;
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
        CreateMap<FactionDto, FactionViewModel>().IgnoreAllNull();
        CreateMap<FactionDto, FactionDetailViewModel>().IgnoreAllNull();
    }

    private void ConfigureCreateModelToDTO()
    {
    }
}