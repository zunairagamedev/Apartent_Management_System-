using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ams_practice.service
{
    public class ServiceServicess
    {
        private ServiceRepositry repo;
        private service_request_repository requestRepo;

        public ServiceServicess(
            ServiceRepositry repository,
            service_request_repository requests)
        {
            repo = repository;
            requestRepo = requests;
        }

        // Provider Login
        public ServiceModel Login(string username, string password)
        {
            return repo.Login(username, password);
        }

        // View Customer Requests
        public List<ServiceRequestModel> ViewRequests(string providerType)
        {
            return requestRepo.GetProviderRequests(providerType);
        }

        // Update Request Status
        public bool UpdateRequest(int id, string status)
        {
            return requestRepo.UpdateStatus(id, status);
        }
    }
}