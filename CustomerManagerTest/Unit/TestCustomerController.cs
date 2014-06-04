namespace CustomerManagerTest.Unit
{
    using CustomerManager.ViewModels;
    using CustomerManagerTest.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class CustomerListVMTests
    {
        private CustomerListVM viewModel;

        [TestInitialize]
        public void Initialize()
        {
            this.viewModel = new CustomerListVM(new TestCustomerService(), new TestNavigationService());
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldLoadCustomersDuringConstruction()
        {
            Assert.IsTrue(this.viewModel.Customers.Count > 0);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldChangeSelectionWhenAdding()
        {
            var oldSelectedCustomer = this.viewModel.SelectedCustomer;
            this.viewModel.AddNewCustomerCommand.Execute(null);
            var newSelectedCustomer = this.viewModel.SelectedCustomer;

            Assert.IsTrue(oldSelectedCustomer != newSelectedCustomer);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldHaveEmptyCustomerSelectedWhenAdding()
        {
            this.viewModel.AddNewCustomerCommand.Execute(null);
            var selectedCustomer = this.viewModel.SelectedCustomer;

            Assert.IsTrue(selectedCustomer.FirstName == string.Empty);
            Assert.IsTrue(selectedCustomer.LastName == string.Empty);
            Assert.IsTrue(selectedCustomer.Birthday != DateTime.MinValue);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldHaveChosenCustomerSelectedWhenEditing()
        {
            var customerToEdit = viewModel.Customers.First();
            this.viewModel.NavigateToCustomerEditCommand.Execute(customerToEdit);

            Assert.IsTrue(this.viewModel.SelectedCustomer == customerToEdit);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldHaveChosenCustomerSelectedWhenViewingDetail()
        {
            var customerToView = viewModel.Customers.First();
            this.viewModel.NavigateToCustomerDetailCommand.Execute(customerToView);

            Assert.IsTrue(this.viewModel.SelectedCustomer == customerToView);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        [ExpectedException(typeof(System.Reflection.TargetInvocationException))]
        public void ShouldThrowExceptionWhenNoCustomerProvidedToEditCommand()
        {
            this.viewModel.NavigateToCustomerEditCommand.Execute(null);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        [ExpectedException(typeof(System.Reflection.TargetInvocationException))]
        public void ShouldThrowExceptionWhenNoCustomerProvidedToDetailCommand()
        {
            this.viewModel.NavigateToCustomerDetailCommand.Execute(null);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldPersistChangesWhenSaveIsCalled()
        {
            var birthday = new DateTime(year: 2000, month: 3, day: 14, hour: 1, minute: 59, second: 26);
            this.viewModel.Customers.First().Birthday = birthday;
            this.viewModel.SaveCommand.Execute(null);

            Assert.IsTrue(this.viewModel.Customers.First().Birthday == birthday);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldNavigateToCustomerListWithoutError()
        {
            this.viewModel.NavigateToCustomerListCommand.Execute(null);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldRemoveCustomerOnDeleteCommand()
        {
            var customerToDelete = this.viewModel.Customers.First();
            this.viewModel.DeleteCommand.Execute(customerToDelete);
            Assert.IsFalse(this.viewModel.Customers.Contains(customerToDelete));
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldHaveAddressTypesAfterConstructor()
        {
            Assert.IsTrue(this.viewModel.AddressTypes.Count > 0);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldRemoveEmailAddressOnDeleteEmailAddressCommand()
        {
            var emailAddresses = this.viewModel.Customers.First().EmailAddresses;
            var emailAddressToDelete = emailAddresses.First();
            this.viewModel.DeleteEmailAddressCommand.Execute(emailAddressToDelete);
            Assert.IsFalse(emailAddresses.Contains(emailAddressToDelete));
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        [ExpectedException(typeof(System.Reflection.TargetInvocationException))]
        public void ShouldThrowExceptionWhenAttemptingToDeleteNullEmail()
        {
            this.viewModel.DeleteEmailAddressCommand.Execute(null);
        }

        [TestMethod]
        [TestTraits(Trait.Unit)]
        public void ShouldAddNewEmailAddressOnAddNewEmailAddressCommand()
        {
            var oldCount = this.viewModel.Customers.First().EmailAddresses.Count();
            this.viewModel.AddNewEmailAddressCommand.Execute(null);
            var newCount = this.viewModel.Customers.First().EmailAddresses.Count();

            Assert.IsTrue(oldCount != newCount);
        }
    }
}
