namespace CustomerManager.Services
{
    using CustomerManager.Models;
    using System;
    using System.Collections.Generic;

    public class CustomerService : ICustomerService
    {
        public IEnumerable<CustomerDTO> List()
        {
            var list = new List<CustomerDTO>();

            var josh = new CustomerDTO
            {
                Id = 1,
                FirstName = "Josh",
                LastName = "Graham",
                Birthday = new DateTime(year: 1988, month: 1, day: 12),
            };

            var brandy = new CustomerDTO
            {
                Id = 2,
                FirstName = "Brandy",
                LastName = "Graham",
                Birthday = new DateTime(year: 1988, month: 9, day: 24),
            };

            var fred = new CustomerDTO
            {
                Id = 3,
                FirstName = "Fred",
                LastName = "Flinstone",
                Birthday = new DateTime(year: 100, month: 3, day: 12)
            };

            var wilma = new CustomerDTO
            {
                Id = 3,
                FirstName = "Wilma",
                LastName = "Flinstone",
                Birthday = new DateTime(year: 102, month: 4, day: 18)
            };

            list.Add(josh);
            list.Add(brandy);
            list.Add(fred);
            list.Add(wilma);

            return list;
        }

        public Models.CustomerDTO Get(int id)
        {
            if (id == 1)
            {
                return new CustomerDTO
                {
                    Id = 1,
                    FirstName = "Josh",
                    LastName = "Graham",
                    Birthday = new DateTime(year: 1988, month: 1, day: 12),
                };
            }
            else if (id == 2)
            {
                return new CustomerDTO
                {
                    Id = 2,
                    FirstName = "Brandy",
                    LastName = "Graham",
                    Birthday = new DateTime(year: 1988, month: 9, day: 24),
                };

            }
            else
            {
                return null;
            }
        }
    }
}
