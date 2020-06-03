using AuxiliaryLayer.Models;
using BusinessLayer;
using System;

namespace HomeWork28
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = new CustomerManager();
            var newCustomer = new Customer();
            newCustomer.Customer_first_name = "Matt";
            newCustomer.Customer_last_name = "LeBlanc";
            newCustomer.Customer_id = "RT-46735";

            var newCustomer2 = new Customer();
            newCustomer2.Customer_first_name = "Bill";
            newCustomer2.Customer_last_name = "Oruell";
            newCustomer2.Customer_id = "UO-15432";
            newCustomer2.segment_id = 2;

            var customers = customerManager.GetAllCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }

            Console.WriteLine(customerManager.DeleteCustomerById("4"));
            Console.WriteLine(customerManager.InsertCustomer(newCustomer));
            Console.WriteLine(customerManager.GetCustomerById("CG-12520"));
            Console.WriteLine(customerManager.DeleteCustomerById("TR-98765"));

            Console.WriteLine(customerManager.InsertCustomer(newCustomer2));

            Console.ReadKey();
        }
    }
}
