using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ams_practice;
using ams_practice.Admin;




    namespace ams_practice
    {
        public class ams
        {
            public void Start()
            {
                Admin_Model admin = new Admin_Model();

                Console.WriteLine("Welcome to Apartment Management System");

                bool running = true;

                while (running)
                {
                    string option = MainMenue();

                    switch (option)
                    {
                        case "1":
                            Console.WriteLine("Admin Management System");
                            break;

                        case "2":
                            Console.WriteLine("Customer Management System");
                            break;

                        case "3":
                            Console.WriteLine("Guest Management System");
                            break;

                        case "4":
                            Console.WriteLine("Exiting Program...");
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid Option! Try again.");
                            break;
                    }
                }
            }

            public string MainMenue()
            {
                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.WriteLine("       APARTMENT MANAGEMENT SYSTEM");
                Console.WriteLine("========================================");

                Console.WriteLine("1. Admin Management System");
                Console.WriteLine("2. Customer Management System");
                Console.WriteLine("3. Guest Management System");
                Console.WriteLine("4. Exit the Program");

                Console.Write("Enter your choice: ");

                return Console.ReadLine() ?? "";
            }
        }
    }
