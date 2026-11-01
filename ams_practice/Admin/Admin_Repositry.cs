using System.Collections.Generic;
using System.Linq;
using ams_practice.service;
using ams_practice.Customer;
using ams_practice.Guest;

namespace ams_practice.Admin
{
    public class Admin_Repositry
    {
        // In-memory storage
        private List<Admin_Model> Admins =
            new List<Admin_Model>();

        private List<ServiceModel> Providers =
            new List<ServiceModel>();

        private List<Customer_Model> Customers =
            new List<Customer_Model>();

        private List<Guest_Model> Guests =
            new List<Guest_Model>();

        // ID counters
        private int nextAdminId = 1;
        private int nextProviderId = 101;
        private int nextCustomerId = 1;
        private int nextGuestId = 1;

        // Add Admin
        public void AddAdmin(Admin_Model admin)
        {
            admin.AdminId = nextAdminId++;
            Admins.Add(admin);
        }

        // Get All Admins
        public List<Admin_Model> GetAllAdmins()
        {
            return Admins;
        }

        // Add Provider
        public void AddProvider(ServiceModel provider)
        {
            provider.ProviderId = nextProviderId++;
            Providers.Add(provider);
        }

        // Get All Providers
        public List<ServiceModel> GetAllProviders()
        {
            return Providers;
        }

        // Search Provider
        public ServiceModel SearchProvider(int id)
        {
            return Providers.FirstOrDefault(
                x => x.ProviderId == id
            );
        }

        // Delete Provider
        public bool DeleteProvider(int id)
        {
            ServiceModel provider = SearchProvider(id);

            if (provider == null)
            {
                return false;
            }

            Providers.Remove(provider);
            return true;
        }

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

        // Add Guest
        public void AddGuest(Guest_Model guest)
        {
            guest.GuestId = nextGuestId++;
            Guests.Add(guest);
        }

        // Get All Guests
        public List<Guest_Model> GetAllGuests()
        {
            return Guests;
        }
    }
}