namespace CustomerManager.Models
{
    using CustomerManager.Utils;
    using MvvmValidation;
    using System;
    using System.Collections.ObjectModel;

    public class CustomerM : ModelBase
    {
        private Guid id;
        private string firstName;
        private string lastName;
        private DateTime birthday;
        private ObservableCollection<EmailAddressM> emailAddresses;

        public CustomerM()
        {
            this.Id = Guid.NewGuid();
            this.firstName = string.Empty;
            this.lastName = string.Empty;
            this.birthday = DateTime.Now.AddYears(-25);
            this.EmailAddresses = new ObservableCollection<EmailAddressM>();

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
                this.Set(() => this.FirstName, ref this.firstName, value);
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
                this.Set(() => this.LastName, ref this.lastName, value);
                this.Validator.Validate(() => this.LastName);
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
                this.Validator.Validate(() => this.Birthday);
            }
        }

        public ObservableCollection<EmailAddressM> EmailAddresses
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
                    ErrorMessages.PropertyMustBeBetween("Birthday", DateTime.Now.AddYears(-150).ToShortDateString(), DateTime.Now.ToShortDateString())));
        }
    }
}
