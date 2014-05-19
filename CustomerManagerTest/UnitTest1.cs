namespace CustomerManagerTest
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CustomerManager.Services;

    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public void TestList()
        {
            var customerService = new CustomerService();
            var customers = customerService.List();

            Assert.IsTrue(customers.Count() > 0);
        }
    }
}
