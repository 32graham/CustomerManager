namespace CustomerManager.Services
{
    using CustomerManager.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomerService
    {
        Task<IEnumerable<CustomerVM>> List();

        Task<CustomerVM> Get(Guid id);

        Task Save(CustomerVM customer);

        Task Delete(CustomerVM customer);

        Task<IEnumerable<AddressTypeVM>> ListAddressTypes();
    }
}
