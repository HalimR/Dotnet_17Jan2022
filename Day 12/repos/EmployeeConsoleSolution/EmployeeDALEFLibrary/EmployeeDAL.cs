using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeModelLibrary;

namespace EmployeeDALEFLibrary
{
    public class EmployeeDAL
    {
        readonly EmployeeContext _employeeContext;
        public EmployeeDAL()
        {
            _employeeContext = new EmployeeContext();
        }

        #region Employee
        public ICollection<Employee> GetAllEmployee()
        {
            List<Employee> employees = _employeeContext.Employees.ToList();
            if (employees.Count == 0)
                throw new NoRecordException();
            return employees;
        }
        public bool InsertNewEmployee(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return true;
        }
        public bool UpdateEmployeeAge(Employee emp)
        {
            Employee employee = _employeeContext.Employees.SingleOrDefault(p => p.Id == emp.Id);
            if (employee == null)
                return false;
            employee.Age = emp.Age;
            _employeeContext.SaveChanges();
            return true;
        }

        public bool UpdateEmployeeDepartment(Employee emp)
        {
            Employee employee = _employeeContext.Employees.SingleOrDefault(p => p.Id == emp.Id);
            if (employee == null)
                return false;
            employee.Department_Id = emp.Department_Id;
            _employeeContext.SaveChanges();
            return true;
        }
        #endregion

        #region Department
        public ICollection<Department> GetAllDepartment()
        {
            List<Department> departments = _employeeContext.Depatments.ToList();
            if (departments.Count == 0)
                throw new NoRecordException();
            return departments;
        }
        public bool InsertNewDepartment(Department dept)
        {
            _employeeContext.Depatments.Add(dept);
            _employeeContext.SaveChanges();
            return true;
        }
        public bool UpdateDepartmentName(Department dept)
        {
            Department deptartment = _employeeContext.Depatments.SingleOrDefault(p => p.Id == dept.Id);
            if (dept == null)
                return false;
            deptartment.Name = dept.Name;
            _employeeContext.SaveChanges();
            return true;
        }

        #endregion

    }
}
