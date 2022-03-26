using AutoMapper;
using AccountBalance.API.Domain.Models;
using AccountBalance.API.Dtos;

namespace AccountBalance.API.Mapping
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Transaction, TransactionDto>();

            CreateMap<CustomerDto, Customer>();
            CreateMap<AccountDto, Account>();
            CreateMap<TransactionDto, Transaction>();
            CreateMap<SaveAccountDto, Account>();
        }
    }
}