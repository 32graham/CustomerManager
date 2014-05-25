namespace CustomerManager.Services
{
    using CustomerManager.ViewModels;
    using CustomerManager.Views;
    using Microsoft.Practices.ServiceLocation;
    using System.Windows;

    public class NavigationService : INavigationService
    {
        private System.Windows.Controls.Frame Frame
        {
            get
            {
                return (Application.Current.MainWindow as CustomerManager.MainWindow).MainFrame;
            }
        }

        public void GoBack()
        {
            this.Frame.GoBack();
        }

        public void NavigateToCustomerList()
        {
            var view = ServiceLocator.Current.GetInstance<CustomerListV>();
            this.Frame.Navigate(view);
        }

        public void NavigateToCustomerDetail()
        {
            var view = new CustomerDetailV();
            this.Frame.Navigate(view);
        }

        public void NavigateToCustomerEdit()
        {
            var view = new CustomerEditV();
            this.Frame.Navigate(view);
        }

        public void NavigateToEmailAddressDetail()
        {
            var view = new EmailAddressDetailV();
            this.Frame.Navigate(view);
        }

        public void NavigateToEmailAddressEdit()
        {
            var view = new EmailAddressEditV();
            this.Frame.Navigate(view);
        }
    }
}
