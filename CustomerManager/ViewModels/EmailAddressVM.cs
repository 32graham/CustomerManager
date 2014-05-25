using CustomerManager.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.ViewModels
{
    public class EmailAddressVM : ViewModelBase
    {
        private Guid id;
        private AddressTypeVM addressType;
        private string address;

        public Guid Id
        {
            get
            {
                return this.id;
            }

            private set
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
            }
        }

        public static EmailAddressVM FromModel(EmailAddressM model)
        {
            return new EmailAddressVM
            {
                Id = model.Id,
                AddressType = AddressTypeVM.FromModel(model.AddressType),
                Address = model.Address,
            };
        }

        public EmailAddressM ToModel()
        {
            return new EmailAddressM
            {
                Id = this.Id,
                AddressType = this.AddressType.ToModel(),
                Address = this.Address,
            };
        }
    }
}
