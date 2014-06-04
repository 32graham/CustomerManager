namespace CustomerManager.Services
{
    using AutoMapper;
    using CustomerManager.DTOs;
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
        private List<CustomerM> customers;
        private List<AddressTypeM> addressTypes;
        private JavaScriptSerializer serializer;
        private string dataFilePath;

        public CustomerService()
        {
            this.serializer = new JavaScriptSerializer();
            this.customers = new List<CustomerM>();
            this.dataFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            this.dataFilePath = Path.Combine(this.dataFilePath, @"customers.json");

            if (!File.Exists(this.dataFilePath))
            {
                var stream = File.Create(this.dataFilePath);
                stream.Dispose();
            }

            var fileContents = string.Join(string.Empty, File.ReadAllLines(this.dataFilePath));

            var dtos = this.serializer.Deserialize<CustomerDTO[]>(fileContents);

            if (dtos == null)
            {
                this.customers = new List<CustomerM>();
            }
            else
            {
                this.customers = Mapper.Map<IEnumerable<CustomerM>>(dtos).ToList();
            }

            this.addressTypes = new List<AddressTypeM>();

            this.addressTypes.Add(
                new AddressTypeM
                {
                    Id = Guid.Parse("c68c6e84-721f-40ba-aaf9-3df723f8967a"),
                    Name = "Personal",
                });

            this.addressTypes.Add(
                new AddressTypeM
                {
                    Id = Guid.Parse("a70c612a-75f9-435f-a6fb-729d85f1ef2c"),
                    Name = "Work",
                });
        }

        public async Task<IEnumerable<CustomerM>> List()
        {
            await Task.Delay(1000);
            return this.customers;
        }

        public async Task<CustomerM> Get(Guid id)
        {
            await Task.Delay(500);
            return this.customers
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public async Task Save(CustomerM customer)
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

            await this.WriteToDisk();
        }

        public async Task Delete(CustomerM customer)
        {
            var customerToRemove = await this.Get(customer.Id);

            if (customerToRemove != null)
            {
                this.customers.Remove(customerToRemove);
            }

            await this.WriteToDisk();
        }

        public async Task WriteToDisk()
        {
            var dtos = Mapper.Map<IEnumerable<CustomerDTO>>(this.customers);
            var fileContents = this.serializer.Serialize(dtos);
            File.WriteAllText(this.dataFilePath, fileContents);

            await Task.Delay(500);
        }

        public async Task<IEnumerable<AddressTypeM>> ListAddressTypes()
        {
            return this.addressTypes;
        }
    }
}
