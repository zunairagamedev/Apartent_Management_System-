using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ams_practice.Customer
{
    public class Customer_Repositry
    {
        private List<Customer_Model> Customers =
            new List<Customer_Model>();

        private int nextCustomerId = 1;

        // Add Customer
        public void AddCustomer(Customer_Model customer)
        {
            customer.CustomerId = nextCustomerId++;
            Customers.Add(customer);
        }

        // Get All Customers
        public List<Customer_Model> GetAllCustomers()
        {
            return Customers;
        }

        // Search Customer
        public Customer_Model SearchCustomer(int id)
        {
            return Customers.FirstOrDefault(
                x => x.CustomerId == id);
        }

        // Customer Login
        public Customer_Model Login(
            string username, string password)
        {
            return Customers.FirstOrDefault(
                x => x.Username == username &&
                     x.Password == password);
        }
    }
}
