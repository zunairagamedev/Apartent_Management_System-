
using System;
using ams_practice.service;
using ams_practice.Customer;
using ams_practice.Guest;
using ams_practice.Admin;


namespace ams_practice.Admin
{
    public class Admin_UI
    {
        private Admin_Service service;

        // Constructor
        public Admin_UI(Admin_Service adminService)
        {
            service = adminService;
        }

        // Admin Menu
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== ADMINISTRATION =====");
                Console.WriteLine("1. Add Service Provider");
                Console.WriteLine("2. View Service Providers");
                Console.WriteLine("3. Search Service Provider");
                Console.WriteLine("4. Delete Service Provider");
                Console.WriteLine("5. View Customers");
                Console.WriteLine("6. View Guests");
                Console.WriteLine("0. Logout");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        AddProvider();
                        break;

                    case "2":
                        ViewProviders();
                        break;

                    case "3":
                        SearchProvider();
                        break;

                    case "4":
                        DeleteProvider();
                        break;

                    case "5":
                        ViewCustomers();
                        break;

                    case "6":
                        ViewGuests();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        // Add Service Provider
        private void AddProvider()
        {
            ServiceModel provider = new ServiceModel();

            Console.Write("Enter username: ");
            provider.Username = Console.ReadLine() ?? "";

            Console.Write("Enter password: ");
            provider.Password = Console.ReadLine() ?? "";

            Console.Write("Enter provider name: ");
            provider.ProviderName = Console.ReadLine() ?? "";

            Console.WriteLine("\n1. Electrician");
            Console.WriteLine("2. Plumber");
            Console.WriteLine("3. Carpenter");
            Console.WriteLine("4. Gas Maintainer");
            Console.WriteLine("5. Sewerage Maintainer");

            Console.Write("Select provider type: ");
            string type = Console.ReadLine() ?? "";

            switch (type)
            {
                case "1":
                    provider.ProviderType = "Electrician";
                    break;

                case "2":
                    provider.ProviderType = "Plumber";
                    break;

                case "3":
                    provider.ProviderType = "Carpenter";
                    break;

                case "4":
                    provider.ProviderType = "Gas Maintainer";
                    break;

                case "5":
                    provider.ProviderType = "Sewerage Maintainer";
                    break;

                default:
                    Console.WriteLine("Invalid provider type.");
                    return;
            }

            service.AddProvider(provider);

            Console.WriteLine("Provider added successfully!");
        }

        // View Service Providers
        private void ViewProviders()
        {
            var providers = service.ViewProviders();

            if (providers.Count == 0)
            {
                Console.WriteLine("No service providers found.");
                return;
            }

            foreach (var p in providers)
            {
                Console.WriteLine(
                    p.ProviderId + " | " +
                    p.ProviderName + " | " +
                    p.ProviderType);
            }
        }

        // Search Service Provider
        private void SearchProvider()
        {
            Console.Write("Enter provider ID: ");

            int id;

            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            var p = service.SearchProvider(id);

            if (p != null)
            {
                Console.WriteLine("Provider ID: " + p.ProviderId);
                Console.WriteLine("Name: " + p.ProviderName);
                Console.WriteLine("Type: " + p.ProviderType);
            }
            else
            {
                Console.WriteLine("Provider not found.");
            }
        }

        // Delete Service Provider
        private void DeleteProvider()
        {
            Console.Write("Enter provider ID: ");

            int id;

            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            bool deleted = service.RemoveProvider(id);

            if (deleted)
            {
                Console.WriteLine("Provider deleted successfully!");
            }
            else
            {
                Console.WriteLine("Provider not found!");
            }
        }

        // View Customers
        private void ViewCustomers()
        {
            var customers = service.ViewCustomers();

            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found.");
                return;
            }

            foreach (var c in customers)
            {
                Console.WriteLine(
                    c.CustomerId + " | " +
                    c.CustomerName + " | Flat " +
                    c.FlatNumber);
            }
        }

        // View Guests
        private void ViewGuests()
        {
            var guests = service.ViewGuests();

            if (guests.Count == 0)
            {
                Console.WriteLine("No guests found.");
                return;
            }

            foreach (var g in guests)
            {
                Console.WriteLine(
                    g.GuestId + " | " +
                    g.GuestName + " | " +
                    g.AvailabilityStatus + " | " +
                    g.ExitStatus);
            }
        }
    }
}
