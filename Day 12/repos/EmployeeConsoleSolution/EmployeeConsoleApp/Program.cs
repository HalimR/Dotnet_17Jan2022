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
                Console.WriteLine("----------DEPATMENT----------");
                Console.WriteLine("1: Add New Department");
                Console.WriteLine("2: Edit Department Name");
                Console.WriteLine("3: Print all Department");
                Console.WriteLine("----------EMPLOYEE----------");
                Console.WriteLine("4: Add New Employee");
                Console.WriteLine("5: Edit Employee Age");
                Console.WriteLine("6: Edit Employee's Department");
                Console.WriteLine("7: Print all Employees");
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
                            menu.AddDepartment();
                            break;
                        case 2:
                            menu.EditDepartmentName();
                            break;
                        case 3:
                            menu.PrintDepartments();
                            break;
                        case 4:
                            menu.AddEmployee();
                            break;
                        case 5:
                            menu.EditEmployeeAge();
                            break;
                        case 6:
                            menu.EditEmployeeDept();
                            break;
                        case 7:
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
