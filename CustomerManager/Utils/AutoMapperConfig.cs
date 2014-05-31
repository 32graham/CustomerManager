namespace CustomerManager.Utils
{
    using AutoMapper;
    using CustomerManager.Models;
    using CustomerManager.ViewModels;

    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<AddressTypeM, AddressTypeVM>().ReverseMap();
            Mapper.CreateMap<EmailAddressM, EmailAddressVM>().ReverseMap();
            Mapper.CreateMap<CustomerM, CustomerVM>().ReverseMap();
        }
    }
}
