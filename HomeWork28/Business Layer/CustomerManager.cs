using AuxiliaryLayer.Interfaces;
using AuxiliaryLayer.Models;
using DataAccessDapper;
using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class CustomerManager
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerManager()
        {
            //customerRepository = new CustomerRepositoryDapper();
            customerRepository = new CustomerRepositoryADO();
        }
        public IList<Customer> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }

        public int DeleteCustomerById(string id)
        {
            return customerRepository.DeleteCustomerById(id);
        }

        public int InsertCustomer(Customer customer)
        {
            return customerRepository.InsertCustomer(customer);
        }
        public Customer GetCustomerById(string custId)
        {
            return customerRepository.GetCustomerById(custId);
        }
    }
}
