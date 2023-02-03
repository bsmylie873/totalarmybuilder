using AutoMapper;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        ConfigureDomainToDtoModel();
        ConfigureDtoToDomainModel();
    }

    private void ConfigureDomainToDtoModel()
    {
        CreateMap<Account, AccountDto>().ForMember(d=>d.Compositions, o=> o.MapFrom(x=> x.AccountCompositions.Select(y=> y.Composition)));;
    }

    private void ConfigureDtoToDomainModel()
    {
        CreateMap<AccountDto, Account>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.AccountCompositions, o=> o.MapFrom(x=>x.Compositions));
    }
}