namespace CustomerManager.Controllers
{
    using CustomerManager.Services;
    using CustomerManager.ViewModels;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class CustomerListC : ViewModelBase
    {
        private ICustomerService customerService;
        private INavigationService navigationService;
        private ObservableCollection<CustomerVM> customers;
        private CustomerVM selectedCustomer;
        private bool isProcessing;

        public CustomerListC(
            ICustomerService customerService,
            INavigationService navigationService)
        {
            this.customerService = customerService;
            this.navigationService = navigationService;

            this.LoadCustomers();

            this.NavigateToCustomerDetailCommand =
                new RelayCommand<CustomerVM>(this.NavigateToCustomerDetail);
            this.NavigateToCustomerEditCommand =
                new RelayCommand<CustomerVM>(this.NavigateToCustomerEdit);
            this.NavigateToCustomerListCommand =
                new RelayCommand(this.NavigateToCustomerList);

            this.AddNewCustomerCommand = new RelayCommand(this.AddNewCustomer);
            this.SaveCommand = new RelayCommand(this.Save);
            this.RefreshCommand = new RelayCommand(this.LoadCustomers);
        }

        public ICommand NavigateToCustomerDetailCommand { get; private set; }

        public ICommand NavigateToCustomerEditCommand { get; private set; }

        public ICommand NavigateToCustomerListCommand { get; private set; }

        public ICommand AddNewCustomerCommand { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public ICommand RefreshCommand { get; private set; }

        public ObservableCollection<CustomerVM> Customers
        {
            get
            {
                return this.customers;
            }

            private set
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

            private set
            {
                this.Set(() => this.SelectedCustomer, ref this.selectedCustomer, value);
            }
        }

        public bool IsProcessing
        {
            get
            {
                return this.isProcessing;
            }

            private set
            {
                this.Set(() => this.IsProcessing, ref this.isProcessing, value);
            }
        }

        private void NavigateToCustomerDetail(CustomerVM customer)
        {
            this.selectedCustomer = customer;
            this.navigationService.NavigateToCustomerView();
        }

        private void AddNewCustomer()
        {
            var customer = new CustomerVM();
            this.customers.Add(customer);
            this.SelectedCustomer = customer;
            this.navigationService.NavigateToCustomerEdit();
        }

        private async void LoadCustomers()
        {
            try
            {
                this.IsProcessing = true;
                var list = this.customerService.List();
                this.SelectedCustomer = list.FirstOrDefault();
                this.Customers = new ObservableCollection<CustomerVM>(list);
                await Task.Delay(3000);
            }
            finally
            {
                this.IsProcessing = false;
            }
        }

        private void NavigateToCustomerEdit(CustomerVM customer)
        {
            this.selectedCustomer = customer;
            this.navigationService.NavigateToCustomerEdit();
        }

        private void NavigateToCustomerList()
        {
            this.navigationService.NavigateToCustomerList();
        }

        private async void Save()
        {
            try
            {
                this.IsProcessing = true;

                foreach (var customer in this.customers)
                {
                    this.customerService.Save(customer);
                }

                this.navigationService.NavigateToCustomerList();

                await Task.Delay(3000);
            }
            finally
            {
                this.IsProcessing = false;
            }
        }
    }
}