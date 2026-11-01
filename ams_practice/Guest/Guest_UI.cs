using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams_practice.Guest
{
    class Guest_UI
    {

    
        private Guest_Service service;

        public Guest_UI(Guest_Service guestService)
        {
            service = guestService;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== GUEST MANAGEMENT =====");

                Console.WriteLine("1. Guest Registration");
                Console.WriteLine("2. Request Availability");
                Console.WriteLine("3. Waiting Area");
                Console.WriteLine("4. Parking System");
                Console.WriteLine("5. Guest Exit");
                Console.WriteLine("0. Back");

                Console.Write("Enter choice: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        RegisterGuest();
                        break;

                    case "2":
                        UpdateAvailability();
                        break;

                    case "3":
                        UpdateWaitingArea();
                        break;

                    case "4":
                        UpdateParking();
                        break;

                    case "5":
                        GuestExit();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        private void RegisterGuest()
        {
            Guest_Model guest = new Guest_Model();

            Console.Write("Enter guest username: ");
            guest.Username = Console.ReadLine() ?? "";

            Console.Write("Enter guest name: ");
            guest.GuestName = Console.ReadLine() ?? "";

            Console.Write("Enter visit purpose / host flat: ");
            guest.VisitPurpose = Console.ReadLine() ?? "";

            service.RegisterGuest(guest);

            Console.WriteLine("Guest registered successfully!");
            Console.WriteLine($"Guest ID: {guest.GuestId}");
        }

        private void UpdateAvailability()
        {
            Console.Write("Enter guest ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            Console.Write("Enter availability status: ");

            string status = Console.ReadLine() ?? "";

            Console.WriteLine(
                service.UpdateAvailability(id, status)
                ? "Availability updated."
                : "Guest not found.");
        }

        private void UpdateWaitingArea()
        {
            Console.Write("Enter guest ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            Console.Write("Enter waiting area status: ");

            string status = Console.ReadLine() ?? "";

            Console.WriteLine(
                service.UpdateWaitingArea(id, status)
                ? "Waiting area updated."
                : "Guest not found.");
        }

        private void UpdateParking()
        {
            Console.Write("Enter guest ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            Console.Write("Enter parking status: ");

            string status = Console.ReadLine() ?? "";

            Console.WriteLine(
                service.UpdateParking(id, status)
                ? "Parking updated."
                : "Guest not found.");
        }

        private void GuestExit()
        {
            Console.Write("Enter guest ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            Console.WriteLine(
                service.GuestExit(id)
                ? "Guest exit recorded successfully."
                : "Guest not found.");
        }
    }

    
}
