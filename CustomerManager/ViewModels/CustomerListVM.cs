namespace CustomerManager.ViewModels
{
    using CustomerManager.Models;
    using CustomerManager.Services;
    using CustomerManager.Utils;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading;
    using System.Windows.Input;

    public class CustomerListVM : ViewModelBase
    {
        private ICustomerService customerService;
        private INavigationService navigationService;
        private ObservableCollection<CustomerM> customers;
        private ObservableCollection<AddressTypeM> addressTypes;
        private CustomerM selectedCustomer;
        private EmailAddressM selectedEmailAddress;
        private int processCount;

        public CustomerListVM(
            ICustomerService customerService,
            INavigationService navigationService)
        {
            this.customerService = customerService;
            this.navigationService = navigationService;

            this.LoadData();
            this.SetupCommands();
        }

        public ICommand NavigateToCustomerDetailCommand { get; private set; }

        public ICommand NavigateToCustomerEditCommand { get; private set; }

        public ICommand NavigateToCustomerListCommand { get; private set; }

        public ICommand NavigateToEmailAddressDetailCommand { get; private set; }

        public ICommand AddNewCustomerCommand { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public ICommand DeleteEmailAddressCommand { get; private set; }

        public ICommand NavigateToEmailAddressEditCommand { get; private set; }

        public ICommand AddNewEmailAddressCommand { get; private set; }

        public ObservableCollection<CustomerM> Customers
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

        public ObservableCollection<AddressTypeM> AddressTypes
        {
            get
            {
                return this.addressTypes;
            }

            private set
            {
                this.Set(() => this.AddressTypes, ref this.addressTypes, value);
            }
        }

        public CustomerM SelectedCustomer
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

        public EmailAddressM SelectedEmailAddress
        {
            get
            {
                return this.selectedEmailAddress;
            }

            private set
            {
                this.Set(() => this.SelectedEmailAddress, ref this.selectedEmailAddress, value);
            }
        }

        public bool IsProcessing
        {
            get
            {
                return this.processCount > 0;
            }
        }

        private void NavigateToCustomerDetail(CustomerM customer)
        {
            if (customer == null)
            {
                throw new System.ArgumentNullException("customer");
            }

            this.selectedCustomer = customer;
            this.navigationService.NavigateToCustomerDetail();
        }

        private void AddNewCustomer()
        {
            var customer = new CustomerM();
            this.customers.Add(customer);
            this.SelectedCustomer = customer;
            this.navigationService.NavigateToCustomerEdit();
        }

        private async void LoadCustomers()
        {
            try
            {
                Interlocked.Increment(ref this.processCount);
                this.RaisePropertyChanged(() => this.IsProcessing);

                var list = await this.customerService.List();

                this.SelectedCustomer = list.FirstOrDefault();

                if (this.SelectedCustomer != null)
                {
                    this.SelectedEmailAddress =
                        this.SelectedCustomer.EmailAddresses.FirstOrDefault();
                }

                this.Customers = new ObservableCollection<CustomerM>(list);
            }
            finally
            {
                Interlocked.Decrement(ref this.processCount);
                this.RaisePropertyChanged(() => this.IsProcessing);
            }
        }

        private void NavigateToCustomerEdit(CustomerM customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }

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
                Interlocked.Increment(ref this.processCount);
                this.RaisePropertyChanged(() => this.IsProcessing);

                this.navigationService.NavigateToCustomerList();

                foreach (var customer in this.customers)
                {
                    await this.customerService.Save(customer);
                }
            }
            finally
            {
                Interlocked.Decrement(ref this.processCount);
                this.RaisePropertyChanged(() => this.IsProcessing);
            }
        }

        private async void Delete(CustomerM customer)
        {
            try
            {
                Interlocked.Increment(ref this.processCount);
                this.RaisePropertyChanged(() => this.IsProcessing);

                this.navigationService.NavigateToCustomerList();

                await this.customerService.Delete(customer);
                this.SelectedCustomer = null;
                this.Customers.Remove(customer);
            }
            finally
            {
                Interlocked.Decrement(ref this.processCount);
                this.RaisePropertyChanged(() => this.IsProcessing);
            }
        }

        private bool CanDelete(CustomerM customer)
        {
            return customer != null;
        }

        private void NavigateToEmailAddressDetail(EmailAddressM emailAddress)
        {
            this.SelectedEmailAddress = emailAddress;
            this.navigationService.NavigateToEmailAddressDetail();
        }

        private void DeleteEmailAddress(EmailAddressM emailAddress)
        {
            if (emailAddress == null)
            {
                throw new ArgumentNullException("emailAddress");
            }

            this.SelectedCustomer.EmailAddresses.Remove(emailAddress);
            this.SelectedEmailAddress = null;
            this.navigationService.NavigateToCustomerList();
        }

        private void NavigateToEmailAddressEdit(EmailAddressM emailAddress)
        {
            this.SelectedEmailAddress = emailAddress;
            this.navigationService.NavigateToEmailAddressEdit();
        }

        private async void LoadAddressTypes()
        {
            var types = await this.customerService.ListAddressTypes();
            this.AddressTypes = types.ToObservableCollection();
        }

        private void AddNewEmailAddress()
        {
            var emailAddress = new EmailAddressM();
            this.SelectedCustomer.EmailAddresses.Add(emailAddress);
            this.SelectedEmailAddress = emailAddress;
            this.navigationService.NavigateToEmailAddressEdit();
        }

        private void LoadData()
        {
            this.LoadCustomers();
            this.LoadAddressTypes();
        }

        private void SetupCommands()
        {
            this.NavigateToCustomerDetailCommand =
                new RelayCommand<CustomerM>(this.NavigateToCustomerDetail);
            this.NavigateToCustomerEditCommand =
                new RelayCommand<CustomerM>(this.NavigateToCustomerEdit);
            this.NavigateToCustomerListCommand =
                new RelayCommand(this.NavigateToCustomerList);
            this.NavigateToEmailAddressDetailCommand =
                new RelayCommand<EmailAddressM>(this.NavigateToEmailAddressDetail);
            this.NavigateToEmailAddressEditCommand =
                new RelayCommand<EmailAddressM>(this.NavigateToEmailAddressEdit);

            this.DeleteCommand = new RelayCommand<CustomerM>(this.Delete, this.CanDelete);
            this.AddNewCustomerCommand = new RelayCommand(this.AddNewCustomer);
            this.SaveCommand = new RelayCommand(this.Save);
            this.DeleteEmailAddressCommand =
                new RelayCommand<EmailAddressM>(this.DeleteEmailAddress);
            this.AddNewEmailAddressCommand = new RelayCommand(this.AddNewEmailAddress);
        }
    }
}