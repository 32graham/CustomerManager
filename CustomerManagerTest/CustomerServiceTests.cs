namespace CustomerManagerTest
{
    using CustomerManager.Services;
    using CustomerManager.ViewModels;
    using CustomerManagerTest.Services;
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
            var customerService = new TestCustomerService();
            var customers = customerService.List();

            Assert.IsTrue(customers.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Service")]
        public void CustomerServiceSavesCustomers()
        {
            var id = Guid.NewGuid();

            var customerService = new TestCustomerService();
            var customer = new CustomerVM
            {
                Id = id,
                FirstName = "Jon",
                LastName = "Doe",
                Birthday = DateTime.Now,
            };

            customerService.Save(customer);
            var savedCustomer = customerService.Get(id);

            Assert.IsTrue(savedCustomer.Id == id);
            Assert.IsTrue(savedCustomer.FirstName == "Jon");
        }

        [TestMethod]
        [TestCategory("Service")]
        public void CustomerServiceDoesNotDuplicateIds()
        {
            var id = Guid.NewGuid();

            var customerService = new TestCustomerService();
            customerService.Save(new CustomerVM { Id = id, FirstName = "Bob", });
            customerService.Save(new CustomerVM { Id = id, FirstName = "Larry", });

            var count = customerService.List().Where(x => x.Id == id).Count();
            Assert.IsTrue(count == 1);
        }
    }
}
