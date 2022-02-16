using FirstWebAPIApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> _employees = new List<Employee>
        { new Employee { Id = 1, Name = "Timmy", Age = 25 },
        new Employee { Id = 2, Name = "Sarah", Age = 44 },
        new Employee { Id = 3, Name = "Liezl", Age = 27 }};

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employees;
        }

        [HttpGet]
        [Route("SingleEmployee")]
        public Employee Get(int id)
        {
            return _employees.SingleOrDefault(c => c.Id == id);
        }

        [HttpPut]
        public Employee Put(int id, Employee cust)
        {
            var customer = _employees.SingleOrDefault(c => c.Id == id);
            if (customer != null)
            {
                customer.Name = cust.Name;
                customer.Age = cust.Age;
            }
            return customer;
        }

        [HttpDelete]
        public Employee Delete(int id)
        {
            var customer = _employees.IndexOf(_employees.Find(c => c.Id == id));
            if (customer != -1)
            {
                _employees.RemoveAt(customer);
                return _employees.SingleOrDefault(c => c.Id == id);
            }
            return null;
        }

        [HttpPost]
        public Employee Post(Employee employee)
        {
            _employees.Add(employee);
            return employee;
        }
    }
}
