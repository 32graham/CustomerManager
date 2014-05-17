namespace CustomerManager.ViewModels
{
    using CustomerManager.Services;
    using GalaSoft.MvvmLight;
    using System.Collections.Generic;

    public class MainVM : ViewModelBase
    {
        private ICustomerService customerService;
        private INavigationService navigationService;
        private IDialogService dialogService;
        private List<CustomerVM> customers;

        public MainVM(ICustomerService customerService, INavigationService navigationService, IDialogService dialogService)
        {
            this.customerService = customerService;
            this.navigationService = navigationService;
            this.dialogService = dialogService;

            this.customers = new List<CustomerVM>();

            var models = this.customerService.List();

            foreach (var model in models)
            {
                var vm = new CustomerVM(this.navigationService);
                vm.FirstName = model.FirstName;
                vm.LastName = model.LastName;
                vm.Birthday = model.Birthday;

                this.customers.Add(vm);
            }

            this.RaisePropertyChanged(() => this.Customers);
        }

        public string Test
        {
            get
            {
                return "Hello from MainVM.cs";
            }

            set
            {

            }
        }

        public List<CustomerVM> Customers
        {
            get
            {
                return this.customers;
            }
            set
            {
                Set(() => this.Customers, ref this.customers, value);
            }
        }
    }
}