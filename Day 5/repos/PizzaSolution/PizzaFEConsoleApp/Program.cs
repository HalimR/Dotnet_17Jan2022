using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaModelsLibrary;

namespace PizzaFEConsoleApp
{
    class Program
    {
        //Customer customer = new Customer();
        //void RegisterCustomer()
        //{
        //    customer.TakeCustomerDetailsFromUser();
        //}

        //void DisplayCustomer()
        //{
        //    customer.PrintCustomerDetails();
        //}

        static void Main(string[] args)
        {
            //Program program = new Program();
            //program.RegisterCustomer();
            //program.DisplayCustomer();

            ManageCustomer program = new ManageCustomer();
            program.RegisterCustomer();
            program.DisplayCustomer();
            Console.ReadKey();

            //Customer
        }
    }
} 
