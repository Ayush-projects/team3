using AutoMapper;
using BankAtm.DTOS;
using BankAtm.Entities;

namespace BankAtm.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Account, AccountDetailsDTO>();
            CreateMap<Customer, CustomerDetailsDTO>();
            CreateMap<Transaction, TransactionDetailsDTO>();
        }
    }
}
