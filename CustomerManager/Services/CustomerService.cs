namespace CustomerManager.Services
{
    using CustomerManager.Models;
    using CustomerManager.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;

    public class CustomerService : ICustomerService
    {
        List<CustomerVM> customers;
        JavaScriptSerializer serializer;
        string dataFilePath;

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
    }
}
