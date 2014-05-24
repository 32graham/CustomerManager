﻿namespace CustomerManager.Services
{
    using CustomerManager.Models;
    using CustomerManager.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<CustomerVM> List();

        CustomerVM Get(Guid id);

        void Save(CustomerVM customer);
    }
}
