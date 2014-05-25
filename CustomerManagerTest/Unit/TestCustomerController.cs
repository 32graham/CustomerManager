namespace CustomerManagerTest.Unit
{
    using CustomerManager.Controllers;
    using CustomerManager.ViewModels;
    using CustomerManagerTest.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class CustomerListCTests
    {
        private CustomerC controller;

        [TestInitialize]
        public void Initialize()
        {
            this.controller = new CustomerC(new TestCustomerService(), new TestNavigationService());
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldLoadCustomersDuringConstruction()
        {
            Assert.IsTrue(this.controller.Customers.Count > 0);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldHaveNewItemsAfterRefresh()
        {
            var oldFirstObject = this.controller.Customers.First();
            this.controller.RefreshCommand.Execute(null);
            var newFirstObject = this.controller.Customers.First();

            Assert.IsTrue(oldFirstObject != newFirstObject);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldChangeSelectionWhenAdding()
        {
            var oldSelectedCustomer = this.controller.SelectedCustomer;
            this.controller.AddNewCustomerCommand.Execute(null);
            var newSelectedCustomer = this.controller.SelectedCustomer;

            Assert.IsTrue(oldSelectedCustomer != newSelectedCustomer);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldHaveEmptyCustomerSelectedWhenAdding()
        {
            this.controller.AddNewCustomerCommand.Execute(null);
            var selectedCustomer = this.controller.SelectedCustomer;

            Assert.IsTrue(selectedCustomer.FirstName == string.Empty);
            Assert.IsTrue(selectedCustomer.LastName == string.Empty);
            Assert.IsTrue(selectedCustomer.Birthday != DateTime.MinValue);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldHaveChosenCustomerSelectedWhenEditing()
        {
            var customerToEdit = controller.Customers.First();
            this.controller.NavigateToCustomerEditCommand.Execute(customerToEdit);

            Assert.IsTrue(this.controller.SelectedCustomer == customerToEdit);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldHaveChosenCustomerSelectedWhenViewingDetail()
        {
            var customerToView = controller.Customers.First();
            this.controller.NavigateToCustomerDetailCommand.Execute(customerToView);

            Assert.IsTrue(this.controller.SelectedCustomer == customerToView);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        [ExpectedException(typeof(System.Reflection.TargetInvocationException))]
        public void ShouldThrowExceptionWhenNoCustomerProvidedToEditCommand()
        {
            this.controller.NavigateToCustomerEditCommand.Execute(null);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        [ExpectedException(typeof(System.Reflection.TargetInvocationException))]
        public void ShouldThrowExceptionWhenNoCustomerProvidedToDetailCommand()
        {
            this.controller.NavigateToCustomerDetailCommand.Execute(null);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldPersistChangesWhenSaveIsCalled()
        {
            var birthday = new DateTime(year: 2000, month: 3, day: 14, hour: 1, minute: 59, second: 26);
            this.controller.Customers.First().Birthday = birthday;
            this.controller.SaveCommand.Execute(null);

            Assert.IsTrue(this.controller.Customers.First().Birthday == birthday);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldNavigateToCustomerListWithoutError()
        {
            this.controller.NavigateToCustomerListCommand.Execute(null);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldRemoveCustomerOnDeleteCommand()
        {
            this.controller.DeleteCommand.Execute(null);
        }
    }
}
