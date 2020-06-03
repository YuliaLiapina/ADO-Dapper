using AuxiliaryLayer.Interfaces;
using AuxiliaryLayer.Models;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessDapper
{
    public class CustomerRepositoryDapper : ICustomerRepository
    {
        private readonly string connection = string.Empty;
        public CustomerRepositoryDapper()
        {
            connection = ConfigurationManager.ConnectionStrings["DBShipServese"].ConnectionString;
        }
        public int DeleteCustomerById(string id)
        {
            using (SqlConnection scn = new SqlConnection(connection))
            {
                var deletion = "Delete from customers where customer_id=@emp_id";

                var numEmployee = scn.Execute(deletion, new { emp_id = id });
                return numEmployee;
            }
        }

        public IList<Customer> GetAllCustomers()
        {
            using (SqlConnection scn = new SqlConnection(connection))
            {
                var getCustomers = "select customer_first_name, customer_last_name, c.customer_id as custId, o.order_id as ordId, p.product_name " +
                            "from customers c, orders o, order_product op, products p " +
                             "where c.customer_id = o.customer_id and o.order_id = op.order_id and op.product_id = p.product_id";

                var listOfCustomers = scn.Query<Customer>(getCustomers).AsList();
                return listOfCustomers;
            }
        }

        public Customer GetCustomerById(string custId)
        {
            using (SqlConnection scn = new SqlConnection(connection))
            {
                var getting = "select customer_first_name, customer_last_name, c.customer_id as custId, o.order_id as ordId, p.product_name " +
                            "from customers c, orders o, order_product op, products p " +
                             "where c.customer_id = o.customer_id and o.order_id = op.order_id and op.product_id = p.product_id and o.customer_id = @id";
                var getCustomer = scn.QuerySingle<Customer>(getting, new { id = custId });
                return getCustomer;
            }

        }

        public int InsertCustomer(Customer customer)
        {
            using (SqlConnection scn = new SqlConnection(connection))
            {
                var insertion = "Insert into customers values (@custId, @custFn, @custLn, @segm)";

                var numCustomer = scn.Execute(insertion, new { custId = customer.Customer_id, custFn = customer.Customer_first_name, custLn = customer.Customer_last_name, segm = 1 });
                return numCustomer;
            }
        }
    }
}
