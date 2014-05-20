namespace CustomerManager.Services
{
    using CustomerManager.ViewModels;
using System;

    public interface INavigationService
    {
        void GoBack();

        void NavigateToCustomerList();

        void NavigateToCustomerView(CustomerVM customer);

        void NavigateToCustomerEdit(CustomerVM customer);
    }
}
