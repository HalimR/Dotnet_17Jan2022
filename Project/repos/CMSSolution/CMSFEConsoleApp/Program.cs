using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSModelsLibrary;

namespace CMSFEConsoleApp
{
    class Program
    {
        void manageMenu()
        {
            Console.WriteLine("Welcome to menu management");
            int choice = 0;
            ManageMenu menu = new ManageMenu();
            do
            {
                Console.WriteLine("1: Add 3 appointment");
                Console.WriteLine("2: Edit Appointment Price");
                //Console.WriteLine("3: Remove appointment");
                Console.WriteLine("4: Print an appointment detail");
                Console.WriteLine("5: Print All appointments detail");
                Console.WriteLine("0: Exit");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Try again. Please enter a number");
                }
                switch (choice)
                {
                    case 1:
                        menu.AddAppointment();
                        break;
                    case 2:
                        menu.EditAppointmentPrice();
                        break;
                    //case 3:
                    //    menu.RemovePizza();
                    //    break;
                    case 4:
                        menu.PrintSingleAppointmentByID();
                        break;
                    case 5:
                        menu.PrintAppointments();
                        break;
                    case 0:
                        Console.WriteLine("Thank you and good bye....");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again");
                        break;
                }
            } while (choice != 0);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.manageMenu();
            Console.ReadKey();
        }

        //Day 5 commit - Register User and Print user detail (Patient/Doctor)
        //static void Main(string[] args)
        //{
        //    ManageUser program = new ManageUser();

        //    program.RegisterAndDisplayUser();

        //    Console.ReadKey();
        //}
    }
}
