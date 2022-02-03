using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEFConsoleApp
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public void GetDepartmentDetails()
        {
            Console.WriteLine("Please enter Department Name");
            Name = Console.ReadLine();
        }

        public override string ToString()
        {
            return "Department ID: " + Id
                + "\nDepartment Name: " + Name;
        }
    }
}
