namespace CustomerManager.Controllers
{
    using CustomerManager.Services;
    using CustomerManager.ViewModels;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using System.Linq;

    public class CustomerListC : ViewModelBase
    {
        private ICustomerService customerService;
        private INavigationService navigationService;
        private ObservableCollection<CustomerVM> customers;
        private CustomerVM selectedCustomer;

        public CustomerListC(
            ICustomerService customerService,
            INavigationService navigationService)
        {
            this.customerService = customerService;
            this.navigationService = navigationService;

            this.LoadCustomers();

            this.ViewDetailCommand = new RelayCommand<CustomerVM>(this.ViewDetail);
            this.AddNewCustomerCommand = new RelayCommand(this.AddNewCustomer);
            this.NavigateToCustomerEditCommand = new RelayCommand(this.ViewEdit);
            this.SaveCommand = new RelayCommand(this.Save);
        }

        public ICommand ViewDetailCommand { get; private set; }

        public ICommand NavigateToCustomerEditCommand { get; private set; }

        public ICommand AddNewCustomerCommand { get; private set; }

        public ICommand SaveCommand { get; private set; }

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

        private void ViewDetail(CustomerVM customer)
        {
            this.selectedCustomer = customer;
            this.navigationService.NavigateToCustomerView(customer);
        }

        private void AddNewCustomer()
        {
            var customer = new CustomerVM();
            this.customers.Add(customer);
            this.navigationService.NavigateToCustomerEdit(customer);
        }

        private void LoadCustomers()
        {
            this.customers = new ObservableCollection<CustomerVM>();
            var models = this.customerService.List();

            foreach (var model in models)
            {
                var vm = CustomerVM.FromModel(model);
                this.customers.Add(vm);
            }

            this.SelectedCustomer = this.customers.FirstOrDefault();
        }

        private void ViewEdit()
        {
            this.navigationService.NavigateToCustomerEdit(this.selectedCustomer);
        }

        private void Save()
        {
            foreach (var customer in this.customers)
            {
                this.customerService.Save(customer.ToModel());
            }
        }
    }
}