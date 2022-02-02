using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeModelLibrary;
using EmployeeDALLibrary;

namespace EmployeeConsoleApp
{
    internal class ManageMenu
    {
        List<Employee> employees;
        EmployeeDAL employeeDAL;

        public ManageMenu()
        {
            employeeDAL = new EmployeeDAL();

        }

        void GetAllEmployee()
        {
            employees = null;
            try
            {
                employees = employeeDAL.GetAllEmployee().ToList();
            }
            //catch (NoRecordException nre)
            //{
            //    Console.WriteLine(nre.Message);
            //}
            catch (Exception npe)
            {
                Console.WriteLine("Something went wrong. Will fix soon...");
                Console.WriteLine(npe.Message);
            }
        }

        public void AddEmployee()
        {

            Employee employee = new Employee();
            employee.GetEmployeeDetails();
            try
            {
                employeeDAL.InsertNewEmployee(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not add the employee");
                Console.WriteLine(e.Message);
            }
        }

        public void EditEmployeeDetail()
        {
            int id = GetIdFromUser();
            Employee employee = GetEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("Invalid Id. Cannot edit");
                return;
            }
            try
            {
                employee.GetEmployeeDetails();
                employeeDAL.UpdateEmployeeDetail(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update the employee");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Update employee as below: ");
            PrintEmployee(employee);
        }

        public void RemoveEmployeeById()
        {
            int id = GetIdFromUser();
            Employee employee = GetEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("Invalid Id. Cannot edit");
                return;
            }
            try
            {
                employeeDAL.DeleteEmployeeDetail(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not remove the employee");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Update employee as below: ");
            PrintEmployee(employee);
        }

        public Employee GetEmployeeById(int id)
        {
            GetAllEmployee();
            Employee employee = employees.SingleOrDefault(p => p.Id == id);
            return employee;
        }

        int GetIdFromUser()
        {
            Console.WriteLine("Please enter the employee id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry ID. Please try again...");
            }
            return id;
        }
        public void PrintEmployees()
        {
            GetAllEmployee();
            var sortedEmployees = employees.OrderBy(p => p.Id);
            foreach (var item in sortedEmployees)
            {
                if (item != null)
                    PrintEmployee(item);
            }
        }
        public void PrintEmployeeById()
        {
            int id = GetIdFromUser();
            Employee employee = GetEmployeeById(id);
            if (employee != null)
            {
                PrintEmployee(employee);
            }
            else
                Console.WriteLine("No such pizza");
        }

        private void PrintEmployee(Employee item)
        {

            Console.WriteLine("**************************");
            Console.WriteLine(item);
            Console.WriteLine("**************************");
        }
    }
}
