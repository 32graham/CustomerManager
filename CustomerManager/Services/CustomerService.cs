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

            list.Add(josh);
            list.Add(brandy);

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
