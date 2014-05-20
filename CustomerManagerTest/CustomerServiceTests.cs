namespace CustomerManagerTest
{
    using CustomerManager.Models;
    using CustomerManager.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public void CustomerServiceListsCustomers()
        {
            var customerService = new CustomerService();
            var customers = customerService.List();

            Assert.IsTrue(customers.Count() > 0);
        }

        [TestMethod]
        public void CustomerServiceSavesCustomers()
        {
            var customerService = new CustomerService();
            var customer = new CustomerDTO
            {
                Id = 42,
                FirstName = "Jon",
                LastName = "Doe",
                Birthday = DateTime.Now,
            };

            customerService.Save(customer);
            var savedCustomer = customerService.Get(42);

            Assert.IsTrue(savedCustomer.Id == 42);
            Assert.IsTrue(savedCustomer.FirstName == "Jon");
        }
    }
}
