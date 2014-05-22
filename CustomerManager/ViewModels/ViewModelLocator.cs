using CustomerManager.ViewModels;
namespace CustomerManager.ViewModel
{
    using CustomerManager.Controllers;
    using CustomerManager.Services;
    using CustomerManager.ViewModels;
    using CustomerManager.Views;
    using GalaSoft.MvvmLight.Ioc;
    using Microsoft.Practices.ServiceLocation;
    using System.Windows;

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<ICustomerService, CustomerService>();
            SimpleIoc.Default.Register<MainVM>();
            SimpleIoc.Default.Register<CustomerListC>();
            SimpleIoc.Default.Register<CustomerList>();
        }

        public MainVM MainVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainVM>();
            }
        }

        public CustomerListC CustomerListC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CustomerListC>();
            }
        }

        public static void Cleanup()
        {
        }
    }
}