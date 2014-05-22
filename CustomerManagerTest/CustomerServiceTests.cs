namespace CustomerManagerTest
{
    using CustomerManager.Services;
    using CustomerManager.ViewModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        [TestCategory("Service")]
        public void CustomerServiceListsCustomers()
        {
            var customerService = new CustomerService();
            var customers = customerService.List();

            Assert.IsTrue(customers.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Service")]
        public void CustomerServiceSavesCustomers()
        {
            var customerService = new CustomerService();
            var customer = new CustomerVM
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

        [TestMethod]
        [TestCategory("Service")]
        public void CustomerServiceDoesNotDuplicateIds()
        {
            var customerService = new CustomerService();
            customerService.Save(new CustomerVM { Id = 96, FirstName = "Bob", });
            customerService.Save(new CustomerVM { Id = 96, FirstName = "Larry", });

            var count = customerService.List().Where(x => x.Id == 96).Count();
            Assert.IsTrue(count == 1);
        }
    }
}
