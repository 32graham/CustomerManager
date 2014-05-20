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
            var view = ServiceLocator.Current.GetInstance<CustomerList>();
            this.Frame.Navigate(view);
        }

        public void NavigateToCustomerView(ViewModels.CustomerVM customer)
        {
            var view = new CustomerView();
            view.DataContext = customer;
            this.Frame.Navigate(view);
        }

        public void NavigateToCustomerEdit(ViewModels.CustomerVM customer)
        {
            var view = new CustomerEdit();
            view.DataContext = customer;
            this.Frame.Navigate(view);
        }
    }
}
