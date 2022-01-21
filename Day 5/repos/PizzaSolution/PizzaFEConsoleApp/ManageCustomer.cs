using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaModelsLibrary;

namespace PizzaFEConsoleApp
{
    internal class ManageCustomer
    {
        Customer[] customers = new Customer[3];
        public void RegisterCustomer()
        {
            for (int i = 0; i < customers.Length; i++)
            {
                customers[i] = new Customer();
                customers[i].TakeCustomerDetailsFromUser();
            }
        }
        public void DisplayCustomer()
        {
            //customer.PrintCustomerDetails();
            for (int i = 0; i < customers.Length; i++)
            {
                Console.WriteLine(customers[i]);
            }
        }

    }
}
