using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEFConsoleApp
{
    public class Employee
    {
        ManageMenu menu = new ManageMenu();

        [Key] //Automatic if its just Id
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Department_Id { get; set; }
        
        [ForeignKey("Department_Id")]
        public Department department { get; set; }

        public void GetEmployeeDetails(int choice) //1-age, 2-deptid, 3-all
        {
            if (choice == 3)
            {
                Console.WriteLine("Please enter Employee Name");
                Name = Console.ReadLine();
            }
            if (choice == 1 || choice == 3)
            {
                Console.WriteLine("Please enter your age");
                int age;
                while (!int.TryParse(Console.ReadLine(), out age))
                {
                    Console.WriteLine("Invalid entry for age. Please try again...");
                }
                Age = age;
            }
            if (choice == 2 || choice == 3)
            {
                menu.PrintDepartmentList();
                Console.WriteLine("Please enter depatment Id");
                int deptId;
                while (!int.TryParse(Console.ReadLine(), out deptId))
                {
                    Console.WriteLine("Invalid entry for department Id. Please try again...");
                }
                Department_Id = deptId;
            }
        }
        public override string ToString()
        {
            return "Employee ID: " + Id
                + "\nEmployee Name: " + Name
                + "\nEmployee Age: " + Age
                + "\nEmployee' Department ID: " + Department_Id;
        }

    }
}
