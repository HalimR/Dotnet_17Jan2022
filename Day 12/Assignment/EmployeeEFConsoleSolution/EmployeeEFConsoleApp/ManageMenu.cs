using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEFConsoleApp
{
    internal class ManageMenu
    {
        List<Employee> employees;
        List<Department> departments;
        EmployeeDAL employeeDAL;

        public ManageMenu()
        {
            employeeDAL = new EmployeeDAL();
        }
        int GetIdFromUser(int choice) //1-dept, 2-employee
        {
            if (choice==1)
                Console.WriteLine("Please enter the department id");
            else
                Console.WriteLine("Please enter the employee id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry ID. Please try again...");
            }
            return id;
        }

        #region Employee
        void GetAllEmployee()
        {
            employees = null;
            try
            {
                employees = employeeDAL.GetAllEmployee().ToList();
            }
            catch (NoRecordException nre)
            {
                Console.WriteLine(nre.Message);
            }
            catch (Exception npe)
            {
                Console.WriteLine("Something went wrong. Will fix soon...");
                Console.WriteLine(npe.Message);
            }
        }

        public void AddEmployee()
        {
            Employee employee = new Employee();
            employee.GetEmployeeDetails(3);
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

        public void EditEmployeeAge()
        {
            int id = GetIdFromUser(2);
            Employee employee = GetEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("Invalid Id. Cannot edit");
                return;
            }
            try
            {
                employee.GetEmployeeDetails(1);
                employeeDAL.UpdateEmployeeAge(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update the employee's age");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Update employee as below: ");
            PrintEmployee(employee);
        }

        public void EditEmployeeDept()
        {
            int id = GetIdFromUser(2);
            Employee employee = GetEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("Invalid Id. Cannot edit");
                return;
            }
            try
            {
                employee.GetEmployeeDetails(2);
                employeeDAL.UpdateEmployeeDepartment(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update the employee's department");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Update employee as below: ");
            PrintEmployee(employee);
        }

        //public void RemoveEmployeeById()
        //{
        //    int id = GetIdFromUser(2);
        //    Employee employee = GetEmployeeById(id);
        //    if (employee == null)
        //    {
        //        Console.WriteLine("Invalid Id. Cannot edit");
        //        return;
        //    }
        //    try
        //    {
        //        employeeDAL.DeleteEmployeeDetail(id);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Could not remove the employee");
        //        Console.WriteLine(e.Message);
        //    }
        //    Console.WriteLine("Update employee as below: ");
        //    PrintEmployee(employee);
        //}

        public Employee GetEmployeeById(int id)
        {
            GetAllEmployee();
            Employee employee = employees.SingleOrDefault(p => p.Id == id);
            return employee;
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
            int id = GetIdFromUser(2);
            Employee employee = GetEmployeeById(id);
            if (employee != null)
            {
                PrintEmployee(employee);
            }
            else
                Console.WriteLine("No such employee");
        }

        private void PrintEmployee(Employee item)
        {

            Console.WriteLine("-------------------------");
            Console.WriteLine(item);
            Console.WriteLine("-------------------------");
        }
        #endregion

        #region Department
        void GetAllDepartment()
        {
            departments = null;
            try
            {
                departments = employeeDAL.GetAllDepartment().ToList();
            }
            catch (NoRecordException nre)
            {
                Console.WriteLine(nre.Message);
            }
            catch (Exception npe)
            {
                Console.WriteLine("Something went wrong. Will fix soon...");
                Console.WriteLine(npe.Message);
            }
        }

        public void AddDepartment()
        {

            Department department = new Department();
            department.GetDepartmentDetails();
            try
            {
                employeeDAL.InsertNewDepartment(department);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not add the department");
                Console.WriteLine(e.Message);
            }
        }

        public void EditDepartmentName()
        {
            int id = GetIdFromUser(1);
            Department department = GetDepartmentById(id);
            if (department == null)
            {
                Console.WriteLine("Invalid Id. Cannot edit");
                return;
            }
            try
            {
                department.GetDepartmentDetails();
                employeeDAL.UpdateDepartmentName(department);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update the department's name");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Department Name Updated");
            Console.WriteLine("-------------------------");
        }

        public Department GetDepartmentById(int id)
        {
            GetAllDepartment();
            Department department = departments.SingleOrDefault(p => p.Id == id);
            return department;
        }

        public void PrintDepartments()
        {
            GetAllDepartment();
            var sortedDepartments = departments.OrderBy(p => p.Id);
            foreach (var item in sortedDepartments)
            {
                if (item != null)
                    PrintDepartment(item);
            }
        }
        public void PrintDepartmentById()
        {
            int id = GetIdFromUser(1);
            Department department = GetDepartmentById(id);
            if (department != null)
            {
                PrintDepartment(department);
            }
            else
                Console.WriteLine("No such department exist");
        }

        public void PrintDepartmentList()
        {
            try
            {
                var DeptList = employeeDAL.GetAllDepartment().ToList();
                Console.WriteLine("-------------------------");
                //Console.WriteLine("Plese select Department ID (on the far left)");
                Console.WriteLine("| {0,-3} | {1,-20} |", "Id", "Department Name");
                foreach (var item in DeptList)
                {
                    Console.WriteLine("| {0,-3} | {1,-20} |", item.Id, item.Name);
                }
                Console.WriteLine("-------------------------");

            }
            catch (NoRecordException nre)
            {
                Console.WriteLine(nre.Message);
            }
            
        }
        private void PrintDepartment(Department item)
        {

            Console.WriteLine("-------------------------");
            Console.WriteLine(item);
            Console.WriteLine("-------------------------");
        }
        #endregion



    }
}
