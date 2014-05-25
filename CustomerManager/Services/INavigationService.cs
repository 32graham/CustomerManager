namespace CustomerManager.Services
{
    using CustomerManager.ViewModels;
using System;

    public interface INavigationService
    {
        void GoBack();

        void NavigateToCustomerList();

        void NavigateToCustomerDetail();

        void NavigateToCustomerEdit();

        void NavigateToEmailAddressDetail();

        void NavigateToEmailAddressEdit();
    }
}
