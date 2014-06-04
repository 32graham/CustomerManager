namespace CustomerManager
{
    using CustomerManager.Services;
    using CustomerManager.ViewModels;
    using CustomerManager.Views;
    using GalaSoft.MvvmLight.Ioc;
    using Microsoft.Practices.ServiceLocation;

    public class Locator
    {
        public Locator()
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
            SimpleIoc.Default.Register<CustomerListVM>();
            SimpleIoc.Default.Register<CustomerListV>();
        }

        public CustomerListVM CustomerListVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CustomerListVM>();
            }
        }

        public static void Cleanup()
        {
        }
    }
}