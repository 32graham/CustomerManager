namespace CustomerManager.Models
{
    using GalaSoft.MvvmLight;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddressTypeM : ObservableObject, IEquatable<AddressTypeM>
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

        public bool Equals(AddressTypeM other)
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
