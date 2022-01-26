using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSModelsLibrary;

namespace CMSConsoleApp
{
    class Program
    {
        ManageAppointment menuApp = new ManageAppointment();
        ManageUser menuUser = new ManageUser();
        User user = new User();
        Appointment app = new Appointment();
        
        void manageHomepage()
        {
            Console.WriteLine("Welcome to Clinic Management System (CMS) Console App");
            int choice = 0;
            do
            {
                Console.WriteLine("1: Patient");
                Console.WriteLine("2: Doctor");
                Console.WriteLine("0: Exit");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Try again. Please enter a number");
                }
                switch (choice)
                {
                    case 1: case 2:
                        user.UserLogin();
                        var userLogin = menuUser.GetUserById(user.User_Id);
                        if (userLogin.User_Type == 2)
                            Console.WriteLine("Hello there Dr.{0}", userLogin.User_Name);
                        else
                            Console.WriteLine("Hello there {0}", userLogin.User_Name);
                        manageAppointment(userLogin);
                        break;
                    case 0:
                        Console.WriteLine("Thank you and good bye...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again");
                        break;
                }
                Console.WriteLine("========================================");
            } while (choice != 0);
        }

        void manageAppointment(User user)
        {
            int choice = 0;
            if (user.User_Type == 1) //Patient
            {
                do
                {
                    Console.WriteLine("1: Book Appointment");
                    Console.WriteLine("2: Pay Appointment");
                    Console.WriteLine("3: View All Appointment");
                    Console.WriteLine("4: View Profile Detail");
                    Console.WriteLine("0: Exit");
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Try again. Please enter a number");
                    }
                    switch (choice)
                    {
                        case 1:
                            menuApp.BookAppointmentByPatId(user);
                            break;
                        case 2:
                            menuApp.MakePayment(user);
                            break;
                        case 3:
                            menuApp.PrintAppDetailsByPatId(user.User_Id);
                            break;
                        case 4:
                            user.PrintUserDetail(user);
                            break;
                        case 0:
                            Console.WriteLine("Going back...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again");
                            break;
                    }
                    Console.WriteLine("========================================");
                } while (choice != 0);
            }
            else // type = 2 "Doctor"
            {
                do
                {
                    Console.WriteLine("1: View Today's Appointment");
                    Console.WriteLine("2: View Past Appointments");
                    Console.WriteLine("3: Raise payment for Appointment");
                    Console.WriteLine("4: View Profile Detail");
                    Console.WriteLine("0: Exit");
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Try again. Please enter a number");
                    }
                    switch (choice)
                    {
                        case 1:
                            menuApp.PrintAppDetailsByDocId(user.User_Id);
                            break;
                        case 2:
                            Console.WriteLine("2: View Past Appointments");
                            break;
                        case 3:
                            menuApp.RaisePayment(user);
                            break;
                        case 4:
                            user.PrintUserDetail(user);
                            break;
                        case 0:
                            Console.WriteLine("Going back...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again");
                            break;
                    }
                    Console.WriteLine("========================================");
                } while (choice != 0);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.manageHomepage();

            Console.ReadKey();
        }
      
    }
}
