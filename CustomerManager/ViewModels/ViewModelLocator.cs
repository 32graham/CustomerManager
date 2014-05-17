namespace CustomerManager.ViewModel
{
    using CustomerManager.Services;
    using CustomerManager.ViewModels;
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
            
        }

        public MainVM Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainVM>();
            }
        }

        public static void Cleanup()
        {
        }
    }
}