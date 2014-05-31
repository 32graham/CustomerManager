namespace CustomerManager.ViewModels
{
    using AutoMapper;
    using CustomerManager.Models;
    using CustomerManager.Utils;
    using MvvmValidation;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class CustomerVM : ValidatableViewModelBase
    {
        private Guid id;
        private string firstName;
        private string lastName;
        private DateTime birthday;
        private ObservableCollection<EmailAddressVM> emailAddresses;

        public CustomerVM()
        {
            this.Id = Guid.NewGuid();
            this.firstName = string.Empty;
            this.lastName = string.Empty;
            this.birthday = DateTime.Now.AddYears(-25);
            this.EmailAddresses = new ObservableCollection<EmailAddressVM>();

            this.SetupValidation();
        }

        public Guid Id
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
                this.SetAndValidate(() => this.FirstName, ref this.firstName, value);
                this.Validator.Validate(() => this.FirstName);
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
                this.SetAndValidate(() => this.LastName, ref this.lastName, value);
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
                this.SetAndValidate(() => this.Birthday, ref this.birthday, value);
            }
        }

        public ObservableCollection<EmailAddressVM> EmailAddresses
        {
            get
            {
                return this.emailAddresses;
            }

            set
            {
                this.Set(() => this.EmailAddresses, ref this.emailAddresses, value);
            }
        }

        public static CustomerVM FromModel(CustomerM model)
        {
            return Mapper.Map<CustomerVM>(model);
        }

        public CustomerM ToModel()
        {
            return Mapper.Map<CustomerM>(this);
        }

        public override string ToString()
        {
            return this.GetFullName();
        }

        private string GetFullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        private void SetupValidation()
        {
            this.Validator.AddRequiredRule(
                () => this.FirstName,
                ErrorMessages.PropertyIsRequired("First name"));

            this.Validator.AddRequiredRule(
                () => this.LastName,
                ErrorMessages.PropertyIsRequired("Last name"));

            this.Validator.AddRule(
                () => this.Birthday,
                () => RuleResult.Assert(
                    this.Birthday.Between(
                        DateTime.Now.AddYears(-150),
                        DateTime.Now),
                    ErrorMessages.PropertyMustBeBetween(
                        "Birthday",
                        DateTime.Now.AddYears(-150).ToShortDateString(),
                        DateTime.Now.ToShortDateString())));
        }
    }
}