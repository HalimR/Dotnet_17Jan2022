using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaModelsLibrary
{
    public class Customer
    {
        public int MinimumAmount { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        private string phone;

        public string Phone
        {
            get
            {
                string masked = "XXXXXX" + phone.Substring(6, 4);
                return masked;
            }
            set
            {
                phone = value;
            }
        }

        public Customer() //constructor, special method, no retun type, used to initialise value
        {
            MinimumAmount = 100;
        }

        public void TakeCustomerDetailsFromUser()
        {
            Console.WriteLine("Pleae enter the Customer ID");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Pleae enter the Customer Name");
            Name = Console.ReadLine();
            Console.WriteLine("Pleae enter the Customer Phone");
            Phone = Console.ReadLine();
        }

        public void PrintCustomerDetails()
        {
            Console.WriteLine("Customer ID {0} Customer Name {1} Customer Phone {2}", Id, Name, Phone);
        }
    }
}
