namespace CustomerManagerTest.Services
{
    using CustomerManager.Models;
    using CustomerManager.Services;
    using CustomerManager.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;

    public class TestCustomerService : ICustomerService
    {
        private List<CustomerM> customers;

        public async Task<IEnumerable<CustomerM>> List()
        {
            this.customers = new List<CustomerM>();
            var addressTypes = await this.ListAddressTypes();

            var josh = new CustomerM
            {
                Id = Guid.NewGuid(),
                FirstName = "Josh",
                LastName = "Graham",
                Birthday = new DateTime(year: 1988, month: 1, day: 12),
                EmailAddresses = new ObservableCollection<EmailAddressM>
                (
                    new EmailAddressM[]
                    {    
                        new EmailAddressM
                        {
                            Address = "graham.josh@gmail.com",
                            AddressType = addressTypes.First(),
                            Id = Guid.NewGuid(),
                        },
                        new EmailAddressM
                        {
                            Address = "jgraham@cusi.com",
                            AddressType = addressTypes.Last(),
                            Id = Guid.NewGuid(),
                        },
                    }
                )
            };

            var brandy = new CustomerM
            {
                Id = Guid.NewGuid(),
                FirstName = "Brandy",
                LastName = "Graham",
                Birthday = new DateTime(year: 1988, month: 9, day: 24),
            };

            var fred = new CustomerM
            {
                Id = Guid.NewGuid(),
                FirstName = "Fred",
                LastName = "Flinstone",
                Birthday = new DateTime(year: 100, month: 3, day: 12)
            };

            var wilma = new CustomerM
            {
                Id = Guid.NewGuid(),
                FirstName = "Wilma",
                LastName = "Flinstone",
                Birthday = new DateTime(year: 102, month: 4, day: 18)
            };

            this.customers.Add(josh);
            this.customers.Add(brandy);
            this.customers.Add(fred);
            this.customers.Add(wilma);

            return this.customers;
        }

        public async Task<CustomerM> Get(Guid id)
        {
            return this.customers.First(x => x.Id == id);
        }

        public async Task Save(CustomerM customer)
        {
            var existingCustomer = this.customers.FirstOrDefault(x => x.Id == customer.Id);
            if (existingCustomer != null)
            {
                var index = this.customers.IndexOf(existingCustomer);
                this.customers[index] = customer;
            }
            else
            {
                this.customers.Add(customer);
            }
        }

        public async Task Delete(CustomerM customer)
        {
            var customerToRemove = this.customers.First(x => x.Id == customer.Id);
            this.customers.Remove(customerToRemove);
        }

        public async Task<IEnumerable<AddressTypeM>> ListAddressTypes()
        {
            var addressTypes = new List<AddressTypeM>();

            addressTypes.Add(
                new AddressTypeM
                {
                    Id = Guid.NewGuid(),
                    Name = "Personal",
                });

            addressTypes.Add(
                new AddressTypeM
                {
                    Id = Guid.NewGuid(),
                    Name = "Work",
                });

            return addressTypes;
        }
    }
}
