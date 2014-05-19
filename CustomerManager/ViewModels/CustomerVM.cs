using CustomerManager.Services;
using CustomerManager.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace CustomerManager.ViewModels
{
    public class CustomerVM : ViewModelBase
    {
        private string firstName;
        private string lastName;
        private DateTime birthday;
        private INavigationService navigationService;

        public CustomerVM(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            this.FirstName = "Josh";
            this.LastName = "Graham";
            this.Birthday = new DateTime(year: 1988, month: 1, day: 12);

            this.NavigateToCustomerEditCommand = new RelayCommand(this.NavigateToCustomerEdit);
        }

        public ICommand NavigateToCustomerEditCommand { get; private set; }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                Set(() => this.FirstName, ref this.firstName, value);
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
                Set(() => this.LastName, ref this.lastName, value);
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
                Set(() => this.Birthday, ref this.birthday, value);
            }
        }

        public void NavigateToCustomerEdit()
        {
            var view = new CustomerEdit();
            view.DataContext = this;
            this.navigationService.NavigateTo(view);
        }

        public override string ToString()
        {
            return this.FirstName;
        }
    }
}