namespace CustomerManager.Services
{
    using CustomerManager.Models;
    using CustomerManager.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerService : ICustomerService
    {
        private List<CustomerVM> customers;

        public CustomerService()
        {
            this.customers = new List<CustomerVM>();

            var josh = new CustomerVM
            {
                Id = 1,
                FirstName = "Josh",
                LastName = "Graham",
                Birthday = new DateTime(year: 1988, month: 1, day: 12),
            };

            var brandy = new CustomerVM
            {
                Id = 2,
                FirstName = "Brandy",
                LastName = "Graham",
                Birthday = new DateTime(year: 1988, month: 9, day: 24),
            };

            var fred = new CustomerVM
            {
                Id = 3,
                FirstName = "Fred",
                LastName = "Flinstone",
                Birthday = new DateTime(year: 100, month: 3, day: 12)
            };

            var wilma = new CustomerVM
            {
                Id = 3,
                FirstName = "Wilma",
                LastName = "Flinstone",
                Birthday = new DateTime(year: 102, month: 4, day: 18)
            };

            this.customers.Add(josh);
            this.customers.Add(brandy);
            this.customers.Add(fred);
            this.customers.Add(wilma);
        }

        public IEnumerable<CustomerVM> List()
        {
            return this.customers;
        }

        public CustomerVM Get(int id)
        {
            return this.customers.First(x => x.Id == id);
        }

        public void Save(CustomerVM customer)
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
}
}
