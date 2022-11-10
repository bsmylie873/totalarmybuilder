using AutoMapper;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Services;

namespace TotalArmyBuilder.Service.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        ConfigureDomainToViewModel();
    }

    private void ConfigureDomainToViewModel()
    {
        CreateMap<Account, AccountDTO>()
            .ForMember(d => d.Id, o => o.Ignore());
    }
}