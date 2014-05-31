namespace CustomerManager.ViewModels
{
    using AutoMapper;
    using CustomerManager.Models;
    using CustomerManager.Utils;
    using System;

    public class AddressTypeVM : ValidatableViewModelBase, IEquatable<AddressTypeVM>
    {
        private Guid id;
        private string name;

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
            return Mapper.Map<AddressTypeVM>(model);
        }

        public AddressTypeM ToModel()
        {
            return Mapper.Map<AddressTypeM>(this);
        }

        public bool Equals(AddressTypeVM other)
        {
            if (this.Id == Guid.Empty)
            {
                return false;
            }
            else
            {
                return this.Id == other.Id;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
