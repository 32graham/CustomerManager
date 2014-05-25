namespace CustomerManager.ViewModels
{
    using CustomerManager.Models;
using GalaSoft.MvvmLight;
using System;

    public class AddressTypeVM : ViewModelBase
    {
        private Guid id;
        private string name;

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

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.Set(() => this.Name, ref this.name, value);
            }
        }

        public static AddressTypeVM FromModel(AddressTypeM model)
        {
            return new AddressTypeVM
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public AddressTypeM ToModel()
        {
            return new AddressTypeM
            {
                Id = this.Id,
                Name = this.Name,
            };
        }
    }
}
