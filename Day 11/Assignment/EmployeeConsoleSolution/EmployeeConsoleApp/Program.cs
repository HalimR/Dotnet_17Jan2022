using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeConsoleApp
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
                Console.WriteLine("1: Add Employee");
                Console.WriteLine("2: Edit Employee Detail");
                Console.WriteLine("3: Remove Employee Record");
                Console.WriteLine("4: Print an Employee detail");
                Console.WriteLine("5: Print All Employee detail");
                Console.WriteLine("0: Exit");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Try again. Please enter a number");
                }
                try
                {
                    switch (choice)
                    {
                        case 1:
                            menu.AddEmployee();
                            break;
                        case 2:
                            menu.EditEmployeeDetail();
                            break;
                        case 3:
                            menu.RemoveEmployeeById();
                            break;
                        case 4:
                            menu.PrintEmployeeById();
                            break;
                        case 5:
                            menu.PrintEmployees();
                            break;
                        case 0:
                            Console.WriteLine("Good bye");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again");
                            break;
                    }
                }
                catch (NullReferenceException nre)
                {
                    Console.WriteLine("Null by mistake");
                    Console.WriteLine(nre.Message);
                }
                catch (ArgumentOutOfRangeException aore)
                {
                    Console.WriteLine("The employee could not be found");
                    Console.WriteLine(aore.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("expecting a number");
                    Console.WriteLine(fe.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong");
                    Console.WriteLine(e.Message);
                }
            } while (choice != 0);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.manageMenu();
            Console.ReadKey();
        }
    }
}
