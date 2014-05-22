namespace CustomerManager.Services
{
    using CustomerManager.Models;
    using CustomerManager.ViewModels;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<CustomerVM> List();

        CustomerVM Get(int id);

        void Save(CustomerVM customer);
    }
}
