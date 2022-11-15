using AutoMapper;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Api.Profiles;

public class CompositionProfile : Profile
{
    public CompositionProfile()
    {
        ConfigureDTOToViewModel();
    }

    private void ConfigureDTOToViewModel()
    {
        CreateMap<CompositionDto, CompositionViewModel>();

    }

    private void ConfigureCreateModelToDTO()
    {
        CreateMap<CreateCompositionViewModel, CompositionDto>();
        CreateMap<UpdateCompositionViewModel, CompositionDto>();
    } 
}