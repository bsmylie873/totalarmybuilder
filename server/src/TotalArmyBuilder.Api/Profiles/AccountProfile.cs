using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Api.Profiles;

using AutoMapper;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        ConfigureDTOToViewModel();
    }

    private void ConfigureDTOToViewModel()
    {
        CreateMap<AccountDto, AccountViewModel>();

    }

    private void ConfigureCreateModelToDTO()
    {
        CreateMap<CreateAccountViewModel, AccountDto>();
        CreateMap<UpdateAccountViewModel, AccountDto>();
    }
}