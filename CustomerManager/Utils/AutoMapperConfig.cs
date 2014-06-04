namespace CustomerManager.Utils
{
    using AutoMapper;
    using CustomerManager.DTOs;
    using CustomerManager.Models;
    using CustomerManager.ViewModels;

    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<AddressTypeDTO, AddressTypeM>().ReverseMap();
            Mapper.CreateMap<EmailAddressDTO, EmailAddressM>().ReverseMap();
            Mapper.CreateMap<CustomerDTO, CustomerM>().ReverseMap();
        }
    }
}
