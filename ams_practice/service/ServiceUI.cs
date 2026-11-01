using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ams_practice.service;




namespace ams_practice.service
{
    public class ServiceUI
    {
        private ServiceServicess service;

        // Constructor
        public ServiceUI(ServiceServicess providerService)
        {
            service = providerService;
        }

        // Provider Dashboard
        public void ShowMenu(ServiceModel provider)
        {
            while (true)
            {
                Console.WriteLine(
                    "\n===== " + provider.ProviderType + " DASHBOARD =====");

                Console.WriteLine("1. View Service Requests");
                Console.WriteLine("2. Update Request Status");
                Console.WriteLine("0. Logout");

                Console.Write("Enter choice: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        ViewRequests(provider);
                        break;

                    case "2":
                        UpdateStatus();
                        break;

                    case "0":
                        Console.WriteLine("Logging out...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        // View Customer Service Requests
        private void ViewRequests(ServiceModel provider)
        {
            List<ServiceRequestModel> requests =
                service.ViewRequests(provider.ProviderType);

            if (requests.Count == 0)
            {
                Console.WriteLine("No service requests found.");
                return;
            }

            foreach (ServiceRequestModel r in requests)
            {
                Console.WriteLine("\nRequest ID: " + r.RequestId);
                Console.WriteLine("Flat: " + r.FlatNumber);
                Console.WriteLine("Service Type: " + r.ServiceType);
                Console.WriteLine("Description: " + r.Description);
                Console.WriteLine("Status: " + r.Status);
                Console.WriteLine("--------------------");
            }
        }

        // Update Request Status
        private void UpdateStatus()
        {
            Console.Write("Enter request ID: ");

            int id;

            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid request ID.");
                return;
            }

            Console.WriteLine("\n1. Accepted");
            Console.WriteLine("2. In Progress");
            Console.WriteLine("3. Completed");

            Console.Write("Select status: ");

            string choice = Console.ReadLine() ?? "";
            string status = "";

            switch (choice)
            {
                case "1":
                    status = "Accepted";
                    break;

                case "2":
                    status = "In Progress";
                    break;

                case "3":
                    status = "Completed";
                    break;

                default:
                    Console.WriteLine("Invalid status.");
                    return;
            }

            bool updated = service.UpdateRequest(id, status);

            if (updated)
            {
                Console.WriteLine("Request updated successfully.");
            }
            else
            {
                Console.WriteLine("Request not found.");
            }
        }
    }
}

