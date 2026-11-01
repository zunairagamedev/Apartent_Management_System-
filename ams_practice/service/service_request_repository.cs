using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams_practice.service
{
    public class service_request_repository
    {
        // Temporary storage for customer service requests
        private List<ServiceRequestModel> Requests =
            new List<ServiceRequestModel>();

        private int nextRequestId = 1;

        // Add Request
        public void AddRequest(ServiceRequestModel request)
        {
            request.RequestId = nextRequestId++;
            Requests.Add(request);
        }

        // Get All Requests of a Customer
        public List<ServiceRequestModel> GetCustomerRequests(
            int customerId)
        {
            return Requests.Where(
                x => x.CustomerId == customerId
            ).ToList();
        }

        // Get Requests for a Service Provider Type
        public List<ServiceRequestModel> GetProviderRequests ( string providerType)
        {
            return Requests
                .Where ( x => x.ProviderType == providerType
            ).ToList();
        }

        // Update Request Status
        public bool UpdateStatus(int requestId, string status)
        {
            ServiceRequestModel request =
                Requests.FirstOrDefault( x => x.RequestId == requestId
                );

            if (request == null)
            {
                return false;
            }

            request.Status = status;
            return true;
        }

        // Get All Requests
        public List<ServiceRequestModel> GetAllRequests()
        {
            return Requests;
        }
    }
}
