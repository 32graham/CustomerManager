namespace CustomerManager.ViewModel
{
    using CustomerManager.Controllers;
    using CustomerManager.Services;
    using CustomerManager.ViewModels;
    using CustomerManager.Views;
    using GalaSoft.MvvmLight.Ioc;
    using Microsoft.Practices.ServiceLocation;

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
            SimpleIoc.Default.Register<CustomerC>();
            SimpleIoc.Default.Register<CustomerListV>();
        }

        public CustomerC CustomerListC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CustomerC>();
            }
        }

        public static void Cleanup()
        {
        }
    }
}