namespace CustomerManager.ViewModels
{
    using CustomerManager.Models;
    using CustomerManager.Services;
    using CustomerManager.Views;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;

    public class CustomerListVM : ViewModelBase
    {
        private ICustomerService customerService;
        private INavigationService navigationService;
        private List<CustomerVM> customers;
        private CustomerVM selectedCustomer;

        public CustomerListVM(ICustomerService customerService, INavigationService navigationService)
        {
            this.customerService = customerService;
            this.navigationService = navigationService;

            this.customers = new List<CustomerVM>();
            var models = customerService.List();

            foreach (var model in models)
            {
                var vm = new CustomerVM(navigationService);
                vm.FirstName = model.FirstName;
                vm.LastName = model.LastName;
                vm.Birthday = model.Birthday;

                this.customers.Add(vm);
            }

            this.ViewDetailCommand = new RelayCommand(this.ViewDetail);
        }

        public ICommand ViewDetailCommand { get; private set; }

        public List<CustomerVM> Customers
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

        public CustomerVM SelectedCustomer
        {
            get
            {
                return this.selectedCustomer;
            }

            set
            {
                this.Set(() => this.SelectedCustomer, ref this.selectedCustomer, value);
            }
        }

        private void ViewDetail()
        {
            var view = new CustomerView();
            view.DataContext = this.SelectedCustomer;

            this.navigationService.NavigateTo(view);
        }
    }
}