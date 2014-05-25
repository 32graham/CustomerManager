namespace CustomerManagerTest.Services
{
    using CustomerManager.Services;
    using CustomerManager.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TestCustomerService : ICustomerService
    {
        private List<CustomerVM> customers;

        public async Task<IEnumerable<CustomerVM>> List()
        {
            this.customers = new List<CustomerVM>();

            var josh = new CustomerVM
            {
                Id = Guid.NewGuid(),
                FirstName = "Josh",
                LastName = "Graham",
                Birthday = new DateTime(year: 1988, month: 1, day: 12),
            };

            var brandy = new CustomerVM
            {
                Id = Guid.NewGuid(),
                FirstName = "Brandy",
                LastName = "Graham",
                Birthday = new DateTime(year: 1988, month: 9, day: 24),
            };

            var fred = new CustomerVM
            {
                Id = Guid.NewGuid(),
                FirstName = "Fred",
                LastName = "Flinstone",
                Birthday = new DateTime(year: 100, month: 3, day: 12)
            };

            var wilma = new CustomerVM
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

        public async Task<CustomerVM> Get(Guid id)
        {
            return this.customers.First(x => x.Id == id);
        }

        public async Task Save(CustomerVM customer)
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

        public async Task Delete(CustomerVM customer)
        {
            var customerToRemove = this.customers.First(x => x.Id == customer.Id);
            this.customers.Remove(customerToRemove);
        }
    }
}
