namespace CustomerManager.ViewModels
{
    using CustomerManager.Models;
    using MvvmValidation;
    using System;
    using System.Text.RegularExpressions;
    using CustomerManager.Utils;
    using AutoMapper;

    public class EmailAddressVM : ValidatableViewModelBase
    {
        private Guid id;
        private AddressTypeVM addressType;
        private string address;

        public EmailAddressVM()
        {
            this.Validator.AddRequiredRule(() => this.AddressType, "Address type is required");
            this.Validator.AddRequiredRule(() => this.Address, "Email address is required");
            this.Validator.AddRule(
                () => this.Address,
                () => RuleResult.Assert(
                    CannedRegex.EmailAddress.Match(this.Address).Success,
                    "Email address is not formatted correctly"));

            this.Validator.ValidateAll();
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

        public AddressTypeVM AddressType
        {
            get
            {
                return this.addressType;
            }

            set
            {
                this.Set(() => this.AddressType, ref this.addressType, value);
                this.Validator.Validate(() => this.AddressType);
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.Set(() => this.Address, ref this.address, value);
                this.Validator.Validate(() => this.Address);
            }
        }

        public static EmailAddressVM FromModel(EmailAddressM model)
        {
            return Mapper.Map<EmailAddressVM>(model);
        }

        public EmailAddressM ToModel()
        {
            return Mapper.Map<EmailAddressM>(this);
        }
    }
}
