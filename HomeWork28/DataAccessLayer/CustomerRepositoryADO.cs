using AuxiliaryLayer.Interfaces;
using AuxiliaryLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class CustomerRepositoryADO : ICustomerRepository
    {
        private readonly string connection = string.Empty;
        public CustomerRepositoryADO()
        {
            connection = ConfigurationManager.ConnectionStrings["DBShipServese"].ConnectionString;
        }
        public int DeleteCustomerById(string id)
        {
            using (SqlConnection scn = new SqlConnection(connection))
            {
                scn.Open();
               
                var deletion = String.Format("Delete from customers where customer_id='{0}'",id);

                var command = new SqlCommand(deletion, scn);
                int number = command.ExecuteNonQuery();
                scn.Close();
                return number;
            }
        }

        public IList<Customer> GetAllCustomers()
        {
            var listCustomers = new List<Customer>();
            var selection = "select customer_first_name, customer_last_name, c.customer_id as custId, o.order_id as ordId, p.product_name "+
                            "from customers c, orders o, order_product op, products p "+
                             "where c.customer_id = o.customer_id and o.order_id = op.order_id and op.product_id = p.product_id";
            var adapter = new SqlDataAdapter(selection, connection);
            var customerDataSet=new DataSet();
            adapter.Fill(customerDataSet, "Customer");

            foreach(DataRow row in customerDataSet.Tables["Customer"].Rows)
            {
                listCustomers.Add(new Customer((string)row[0], (string)row[1], (string)row[2],(string)row[3], (string)row[4]));
            }
            return listCustomers;
        }

        public Customer GetCustomerById(string id)
        {
            using (SqlConnection scn = new SqlConnection(connection))
            {
                Customer searchCustomer = new Customer();
                scn.Open();
                var getting = String.Format("select customer_first_name, customer_last_name, c.customer_id as custId, " +
                    "o.order_id as ordId, p.product_name from customers c, orders o, order_product op, products p " +
                    "where c.customer_id = o.customer_id and o.order_id = op.order_id and op.product_id = p.product_id " +
                    "and o.customer_id = '{0}'", id);

                var command = new SqlCommand(getting, scn);
                var result= command.ExecuteReader();

                while (result.Read()) 
                {
                    object fName = result.GetValue(0);
                    object lName = result.GetValue(1);
                    object custId = result.GetValue(2);
                    object orderId = result.GetValue(3);
                    object product = result.GetValue(3);

                    searchCustomer.Customer_first_name = (string)fName;
                    searchCustomer.Customer_last_name = (string)lName;
                    searchCustomer.Customer_id = (string)custId;
                    searchCustomer.Order_id = (string)orderId;
                    searchCustomer.Product_name = (string)product;
                }
                return searchCustomer;
            }
        }

        public int InsertCustomer(Customer customer)
        {
            using (SqlConnection scn = new SqlConnection(connection))
            {
                scn.Open();
                var insertion = String.Format("Insert into customers values ('{0}', '{1}', '{2}',{3})",customer.Customer_id, customer.Customer_first_name, customer.Customer_last_name, customer.segment_id);
             
                var command = new SqlCommand(insertion, scn);
                var number = command.ExecuteNonQuery();
                scn.Close();
                return number;            
            }
        }
    }
}
