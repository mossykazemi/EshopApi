﻿using EshopApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopApi.Contracts
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Task<Customer> Add(Customer customer);
        Task<Customer> Find(int id);
        Task<Customer> Update(Customer customer);
        Task<Customer> Remove(int id);
        Task<bool> IsExists(int id);
        Task<int> CountCustomer();
    }
}