namespace CustomerManager.Services
{
    using CustomerManager.Models;
    using CustomerManager.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;

    public class CustomerService : ICustomerService
    {
        private List<CustomerVM> customers;
        private List<AddressTypeVM> addressTypes;
        private JavaScriptSerializer serializer;
        private string dataFilePath;

        public CustomerService()
        {
            this.serializer = new JavaScriptSerializer();
            this.customers = new List<CustomerVM>();
            this.dataFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            this.dataFilePath = Path.Combine(this.dataFilePath, @"customers.json");

            if (!File.Exists(this.dataFilePath))
            {
                File.Create(this.dataFilePath);
            }

            var fileContents = string.Join(string.Empty, File.ReadAllLines(this.dataFilePath));

            var temp = this.serializer.Deserialize<CustomerM[]>(fileContents);

            if (temp == null)
            {
                this.customers = new List<CustomerVM>();
            }
            else
            {
                this.customers = temp.Select(x => CustomerVM.FromModel(x)).ToList();
            }

            var emails = new ObservableCollection<EmailAddressVM>();

            this.addressTypes = new List<AddressTypeVM>();

            addressTypes.Add(
                new AddressTypeVM
                {
                    Id = Guid.NewGuid(),
                    Name = "Personal",
                });

            addressTypes.Add(
                new AddressTypeVM
                {
                    Id = Guid.NewGuid(),
                    Name = "Work",
                });

            emails.Add(new EmailAddressVM
                {
                    Id = Guid.NewGuid(),
                    AddressType = this.addressTypes.First(),
                    Address = "graham.josh@gmail.com",
                });

            var josh = new CustomerVM
            {
                Id = Guid.NewGuid(),
                FirstName = "Josh",
                LastName = "Graham",
                Birthday = new DateTime(year: 1988, month: 1, day: 12),
                EmailAddresses = emails,
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
        }

        public async Task<IEnumerable<CustomerVM>> List()
        {
            await Task.Delay(1000);
            return this.customers;
        }

        public async Task<CustomerVM> Get(Guid id)
        {
            await Task.Delay(500);
            return this.customers
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public async Task Save(CustomerVM customer)
        {
            var existingCustomer = await this.Get(customer.Id);

            if (existingCustomer != null)
            {
                var index = this.customers.IndexOf(existingCustomer);
                this.customers[index] = customer;
            }
            else
            {
                this.customers.Add(customer);
            }

            await WriteToDisk();
        }

        public async Task Delete(CustomerVM customer)
        {
            var customerToRemove = await this.Get(customer.Id);

            if (customerToRemove != null)
            {
                this.customers.Remove(customerToRemove);
            }

            await WriteToDisk();
        }

        public async Task WriteToDisk()
        {
            var fileContents = this.serializer.Serialize(this.customers.Select(x => x.ToModel()));
            File.WriteAllText(this.dataFilePath, fileContents);

            await Task.Delay(500);
        }

        public async Task<IEnumerable<AddressTypeVM>> ListAddressTypes()
        {
            return this.addressTypes;
        }
    }
}
