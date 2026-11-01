using System.Collections.Generic;
using ams_practice.service;

namespace ams_practice.Customer
{
    public class Customer_Service
    {
        private Customer_Repositry customerRepo;
        private service_request_repository requestRepo;
        private customer_record_repository recordRepo;

        // Constructor
        public Customer_Service(
            Customer_Repositry customers,
            service_request_repository requests,
            customer_record_repository records )
        {
            customerRepo = customers;
            requestRepo = requests;
            recordRepo = records;
        }

        // Customer Login
        public Customer_Model Login(
            string username, string password)
        {
            return customerRepo.Login(username, password);
        }

        // Request Flat Service
        public void RequestFlatService(
            Customer_Model customer,
            string serviceType,
            string description)
        {
            ServiceRequestModel request = new   ServiceRequestModel
                {
                    CustomerId = customer.CustomerId,
                    FlatNumber = customer.FlatNumber,
                    ServiceType = serviceType,
                    ProviderType = serviceType,
                    Description = description,
                    Status = "Pending"
                };

            requestRepo.AddRequest(request);
        }

        // Submit Customer Record
        public void SubmitCustomerRecord(
            Customer_Model customer,
            string category,
            string serviceName,
            string description)
        {
            CustomerRecordModel record = new CustomerRecordModel
                {
                    CustomerId = customer.CustomerId,
                    Category = category,
                    ServiceName = serviceName,
                    Description = description,
                    Status = "Pending"
                };

            recordRepo.AddRecord(record);
        }

        // View Customer Requests
        public List<ServiceRequestModel> ViewMyRequests(int id)
        {
            return requestRepo.GetCustomerRequests(id);
        }

        // View Customer Records
        public List<CustomerRecordModel> ViewMyRecords(int id)
        {
            return recordRepo.GetCustomerRecords(id);
        }
    }
}