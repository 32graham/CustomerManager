namespace CustomerManager.ViewModels
{
    using CustomerManager.Services;
    using CustomerManager.Views;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class CustomerListVM : ViewModelBase
    {
        private ICustomerService customerService;
        private INavigationService navigationService;
        private ObservableCollection<CustomerVM> customers;

        public CustomerListVM(ICustomerService customerService, INavigationService navigationService)
        {
            this.customerService = customerService;
            this.navigationService = navigationService;

            this.customers = new ObservableCollection<CustomerVM>();
            var models = customerService.List();

            foreach (var model in models)
            {
                var vm = new CustomerVM(this.navigationService, this.customerService);
                vm.FirstName = model.FirstName;
                vm.LastName = model.LastName;
                vm.Birthday = model.Birthday;

                this.customers.Add(vm);
            }

            this.ViewDetailCommand = new RelayCommand<CustomerVM>(this.ViewDetail);
            this.AddNewCustomerCommand = new RelayCommand(this.AddNewCustomer);
        }

        public ICommand ViewDetailCommand { get; private set; }

        public ICommand AddNewCustomerCommand { get; private set; }

        public ObservableCollection<CustomerVM> Customers
        {
            get
            {
                return this.customers;
            }

            set
            {
                this.Set(() => this.Customers, ref this.customers, value);
            }
        }

        private void ViewDetail(CustomerVM customer)
        {
            this.navigationService.NavigateToCustomerView(customer);
        }

        private void AddNewCustomer()
        {
            var customer = new CustomerVM(this.navigationService, this.customerService);
            this.customers.Add(customer);
            this.navigationService.NavigateToCustomerEdit(customer);
        }
    }
}