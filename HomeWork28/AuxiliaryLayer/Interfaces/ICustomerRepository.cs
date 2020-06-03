using AuxiliaryLayer.Models;
using System.Collections.Generic;

namespace AuxiliaryLayer.Interfaces
{
    public interface ICustomerRepository
    {
        IList<Customer> GetAllCustomers();
        Customer GetCustomerById(string id);
        int InsertCustomer(Customer customer);
        int DeleteCustomerById(string id);
    }
}
