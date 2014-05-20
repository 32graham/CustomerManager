namespace CustomerManager.ViewModels
{
    using CustomerManager.Models;
    using CustomerManager.Services;
    using CustomerManager.Views;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;

    public class CustomerVM : ViewModelBase
    {
        private int id;
        private string firstName;
        private string lastName;
        private DateTime birthday;
        private INavigationService navigationService;
        private ICustomerService customerService;

        public CustomerVM(INavigationService navigationService, ICustomerService customerService)
        {
            this.navigationService = navigationService;
            this.customerService = customerService;

            this.FirstName = "Josh";
            this.LastName = "Graham";
            this.Birthday = new DateTime(year: 1988, month: 1, day: 12);

            this.NavigateToCustomerEditCommand = new RelayCommand(this.NavigateToCustomerEdit);
            this.SaveCommand = new RelayCommand(this.Save);
        }

        public ICommand NavigateToCustomerEditCommand { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.Set(() => this.Id, ref this.id, value);
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.Set(() => this.FirstName, ref this.firstName, value);
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.Set(() => this.LastName, ref this.lastName, value);
            }
        }

        public DateTime Birthday
        {
            get
            {
                return this.birthday;
            }

            set
            {
                this.Set(() => this.Birthday, ref this.birthday, value);
            }
        }

        public void NavigateToCustomerEdit()
        {
            var view = new CustomerEdit();
            view.DataContext = this;
            this.navigationService.NavigateTo(view);
        }

        public CustomerDTO ToModel()
        {
            var model = new CustomerDTO();

            model.Id = this.Id;
            model.FirstName = this.FirstName;
            model.LastName = this.LastName;
            model.Birthday = this.Birthday;

            return model;
        }

        public override string ToString()
        {
            return this.FirstName;
        }

        private void Save()
        {
            this.customerService.Save(this.ToModel());
            this.navigationService.GoBack();
        }
    }
}