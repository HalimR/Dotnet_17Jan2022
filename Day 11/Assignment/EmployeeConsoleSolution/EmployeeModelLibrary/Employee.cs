using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModelLibrary
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void GetEmployeeDetails()
        {
            Console.WriteLine("Please enter Employee Name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter your age");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid entry for age. Please try again...");
            }
            Age = age;
        }
        public override string ToString()
        {
            return "Employee ID: " + Id
                + "\nEmployee Name: " + Name
                + "\nEmployee Age: " + Age;
        }

    }
}
