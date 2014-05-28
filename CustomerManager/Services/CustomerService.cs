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
                var stream = File.Create(this.dataFilePath);
                stream.Dispose();
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


            this.addressTypes = new List<AddressTypeVM>();

            addressTypes.Add(
                new AddressTypeVM
                {
                    Id = Guid.Parse("c68c6e84-721f-40ba-aaf9-3df723f8967a"),
                    Name = "Personal",
                });

            addressTypes.Add(
                new AddressTypeVM
                {
                    Id = Guid.Parse("a70c612a-75f9-435f-a6fb-729d85f1ef2c"),
                    Name = "Work",
                });
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
