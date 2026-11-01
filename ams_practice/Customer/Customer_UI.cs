using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams_practice.Customer
{
    class Customer_UI
    {
        

            private Customer_Service service;

            // Constructor
            public Customer_UI(Customer_Service customerService)
            {
                service = customerService;
            }

            // Customer Dashboard
            public void ShowMenu(Customer_Model  customer)
            {
                while (true)
                {
                    Console.WriteLine("\n===== CUSTOMER DASHBOARD =====");
                    Console.WriteLine("Welcome " + customer.Username);
                    Console.WriteLine("Flat: " + customer.FlatNumber);

                    Console.WriteLine("1. Flat Services");
                    Console.WriteLine("2. Consumer Services");
                    Console.WriteLine("3. Schedule & Subscriptions");
                    Console.WriteLine("4. Security");
                    Console.WriteLine("5. Bills");
                    Console.WriteLine("6. Emergency Services");
                    Console.WriteLine("7. Notifications");
                    Console.WriteLine("8. Complaints & Feedback");
                    Console.WriteLine("9. My Requests");
                    Console.WriteLine("0. Logout");

                    Console.Write("Enter choice: ");
                    string choice = Console.ReadLine() ?? "";

                    switch (choice)
                    {
                        case "1":
                            FlatServices(customer);
                            break;

                        case "2":
                            ConsumerServices(customer);
                            break;

                        case "3":
                            ScheduleServices(customer);
                            break;

                        case "4":
                            Security(customer);
                            break;

                        case "5":
                            Bills(customer);
                            break;

                        case "6":
                            EmergencyServices(customer);
                            break;

                        case "7":
                            Notifications(customer);
                            break;

                        case "8":
                            Complaints(customer);
                            break;

                        case "9":
                            ViewMyRequests(customer);
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
            }

            // Flat Services
            private void FlatServices(Customer_Model customer)
            {
                Console.WriteLine("\n--- FLAT SERVICES ---");
                Console.WriteLine("1. Electrician");
                Console.WriteLine("2. Plumber");
                Console.WriteLine("3. Carpenter");
                Console.WriteLine("4. Gas Maintainer");
                Console.WriteLine("5. Sewerage Maintainer");

                Console.Write("Select service: ");
                string choice = Console.ReadLine() ?? "";

                string type = "";

                switch (choice)
                {
                    case "1":
                        type = "Electrician";
                        break;

                    case "2":
                        type = "Plumber";
                        break;

                    case "3":
                        type = "Carpenter";
                        break;

                    case "4":
                        type = "Gas Maintainer";
                        break;

                    case "5":
                        type = "Sewerage Maintainer";
                        break;

                    default:
                        Console.WriteLine("Invalid selection.");
                        return;
                }

                Console.Write("Describe your problem: ");
                string description = Console.ReadLine() ?? "";

                service.RequestFlatService(customer, type, description);

                Console.WriteLine("Service request submitted!");
            }

            // Consumer Services
            private void ConsumerServices(Customer_Model customer)
            {
                string[] options =
                {
                "Grocery",
                "Pharmacy",
                "Carefore",
                "Restaurant"
            };

                SubmitOption(customer, "Consumer Services", options);
            }

            // Schedule and Subscriptions
            private void ScheduleServices(Customer_Model customer)
            {
                string[] options =
                {
                "Water Filler",
                "Play Area",
                "Swimming Pool",
                "Gym",
                "Parlour",
                "Kitty Party",
                "Mosque",
                "Parking"
            };

                SubmitOption(customer, "Schedule & Subscriptions", options);
            }

            // Security
            private void Security(Customer_Model customer)
            {
                string[] options =
                {
                "CCTV",
                "Security Alerts"
            };

                SubmitOption(customer, "Security", options);
            }

            // Bills
            private void Bills(Customer_Model customer)
            {
                string[] options =
                {
                "Electricity Bill",
                "Gas Bill",
                "Water Bill",
                "PTCL Bill",
                "Cable Bill",
                "Internet Bill"
            };

                SubmitOption(customer, "Bills", options);
            }

            // Emergency Services
            private void EmergencyServices(Customer_Model customer)
            {
                string[] options =
                {
                "Doctor",
                "Robbery",
                "Fire Alarm",
                "Harassment"
            };

                SubmitOption(customer, "Emergency Services", options);
            }

            // Notifications
            private void Notifications(Customer_Model customer)
            {
                string[] options =
                {
                "Updates",
                "Announcements"
            };

                SubmitOption(customer, "Notifications", options);
            }

            // Complaints and Feedback
            private void Complaints(Customer_Model customer)
            {
                string[] options =
                {
                "Complaint",
                "Feedback"
            };

                SubmitOption(customer, "Complaints & Feedback", options);
            }

            // Submit Customer Record
            private void SubmitOption(
                Customer_Model customer,
                string category,
                string[] options)
            {
                Console.WriteLine("\n--- " + category + " ---");

                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + options[i]);
                }

                Console.Write("Select option: ");

                if (!int.TryParse(Console.ReadLine(), out int number))
                {
                    Console.WriteLine("Please enter a valid number.");
                    return;
                }

                if (number < 1 || number > options.Length)
                {
                    Console.WriteLine("Invalid selection.");
                    return;
                }

                Console.Write("Enter details: ");
                string details = Console.ReadLine() ?? "";

                service.SubmitCustomerRecord(
                    customer,
                    category,
                    options[number - 1],
                    details);

                Console.WriteLine("Your request has been submitted!");
            }

            // View My Requests
            private void ViewMyRequests(Customer_Model customer)
            {
                Console.WriteLine("\n--- MY FLAT SERVICE REQUESTS ---");

                var requests = service.ViewMyRequests(customer.CustomerId);

                if (requests.Count == 0)
                {
                    Console.WriteLine("No flat service requests found.");
                }

                foreach (var r in requests)
                {
                    Console.WriteLine(
                        r.RequestId + " | " +
                        r.ServiceType + " | " +
                        r.Status);
                }

                Console.WriteLine("\n--- MY OTHER RECORDS ---");

                var records = service.ViewMyRecords(customer.CustomerId);

                if (records.Count == 0)
                {
                    Console.WriteLine("No other records found.");
                }

                foreach (var r in records)
                {
                    Console.WriteLine(
                        r.RecordId + " | " +
                        r.Category + " | " +
                        r.ServiceName + " | " +
                        r.Status);
                }
            }
    }
}


