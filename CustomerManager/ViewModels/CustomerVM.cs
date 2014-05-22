namespace CustomerManager.ViewModels
{
    using CustomerManager.Models;
    using GalaSoft.MvvmLight;
    using System;

    public class CustomerVM : ViewModelBase
    {
        private int id;
        private string firstName;
        private string lastName;
        private DateTime birthday;

        public CustomerVM()
        {
        }

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

        public static CustomerVM FromModel(CustomerM model)
        {
            return new CustomerVM()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Birthday = model.Birthday,
            };
        }

        public CustomerM ToModel()
        {
            return new CustomerM
            {
                Id = this.Id,
                FirstName = this.firstName,
                LastName = this.LastName,
                Birthday = this.Birthday,
            };
        }

        public override string ToString()
        {
            return this.FirstName;
        }
    }
}