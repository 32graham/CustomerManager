namespace CustomerManager.Services
{
    using CustomerManager.Models;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<CustomerDTO> List();
        CustomerDTO Get(int id);
        void Save(CustomerDTO customer);
    }
}
