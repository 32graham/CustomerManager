using CustomerManager.Services;
using GalaSoft.MvvmLight;
using System;

namespace CustomerManager.ViewModels
{
    public class CustomerVM : ViewModelBase
    {
        private string firstName;
        private string lastName;
        private DateTime birthday;

        public CustomerVM(INavigationService navigationService)
        {
            this.FirstName = "Josh";
            this.LastName = "Graham";
            this.Birthday = new DateTime(year: 1988, month: 1, day: 12);
        }

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

        public override string ToString()
        {
            return this.FirstName;
        }
    }
}