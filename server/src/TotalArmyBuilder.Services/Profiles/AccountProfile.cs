using AutoMapper;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Services;

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
        CreateMap<Account, AccountDto>()
            .ForMember(d => d.Compositions, 
                o=> o
                    .MapFrom(x => x.AccountCompositions.Select(y => y.Composition)));
        
        CreateMap<Account,AccountDto>().ForAllMembers(
            opts => 
                opts.Condition((src, dest, srcMember) => srcMember != null));
    }
    
    private void ConfigureDtoToDomainModel()
    {
        CreateMap<AccountDto, Account>()
            .ForMember(d => d.Id, o => o.Ignore());
            //.ForMember(d => d.Password, o => o.Ignore());
            
        CreateMap<AccountDto, Account>().ForAllMembers(
            opts => 
                opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}