namespace CustomerManager.Services
{
    using CustomerManager.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomerService
    {
        Task<IEnumerable<CustomerM>> List();

        Task<CustomerM> Get(Guid id);

        Task Save(CustomerM customer);

        Task Delete(CustomerM customer);

        Task<IEnumerable<AddressTypeM>> ListAddressTypes();
    }
}
