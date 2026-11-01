using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ams_practice.service;
using ams_practice.Guest;
using ams_practice.Customer;

namespace ams_practice.Admin
{
   public class Admin_Service
    {
      
 
            private Admin_Repositry repo;

            // Constructor
            public Admin_Service(Admin_Repositry repository)
            {
                repo = repository;
            }

            // Add Service Provider
            public void AddProvider(ServiceModel provider)
            {
                repo.AddProvider(provider);
            }

            // View All Service Providers
            public List<ServiceModel> ViewProviders()
            {
                return repo.GetAllProviders();
            }

            // Search Service Provider
            public ServiceModel SearchProvider(int id)
            {
                return repo.SearchProvider(id);
            }

            // Remove Service Provider
            public bool RemoveProvider(int id)
            {
                return repo.DeleteProvider(id);
            }

            // View All Customers
            public List<Customer_Model> ViewCustomers()
            {
                return repo.GetAllCustomers();
            }

            // View All Guests
            public List<Guest_Model> ViewGuests()
            {
                return repo.GetAllGuests();
            }
    }
}
 
