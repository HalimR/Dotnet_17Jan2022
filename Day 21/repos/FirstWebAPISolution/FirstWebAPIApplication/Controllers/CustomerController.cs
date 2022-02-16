using FirstWebAPIApplication.Models;
using FirstWebAPIApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        //private readonly IRepo<int, Customer> _customerService;
        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        //static List<Customer> _customers = new List<Customer>
        //{ new Customer { Id = 1, Name = "Timmy", Age = 25 },
        //new Customer { Id = 2, Name = "Sarah", Age = 44 },
        //new Customer { Id = 3, Name = "Liezl", Age = 27 }};

        [HttpGet]
        public ICollection<Customer> Get()
        {
            //return _customers;
            return _customerService.GetAllCustomer();
            //return _customerService.GetAll();
        }

        [HttpGet]
        [Route("Single")]
        public Customer Get(int id)
        {
            //return _customers.SingleOrDefault(c => c.Id == id);
            return _customerService.GetCustomerById(id);
            //return _customerService.Get(id);
        }

        [HttpPut]
        public Customer Put(int id, Customer cust)
        {
            //var customer = _customers.SingleOrDefault(c => c.Id == id);
            var customer = _customerService.GetCustomerById(id);
            //var customer = _customerService.Get(id);
            if (customer != null)
            {
                customer.Name = cust.Name;
                customer.Age = cust.Age;
                _customerService.UpdateCustomer(customer);
                //_customerService.Update(customer);

            }
            return customer;

        }

        [HttpDelete]
        public Customer Delete(int id)
        {
            //var customer = _customers.IndexOf(_customers.Find(c => c.Id == id));
            var customer = _customerService.GetCustomerById(id);
            //var customer = _customerService.Get(id);
            if (customer != null)
            {
                //_customers.RemoveAt(customer);
                //return _customers.SingleOrDefault(c => c.Id == id);
                _customerService.DeleteCustomer(customer);
                //_customerService.Delete(customer);
                return customer;
            }
            return null;
        }

        [HttpPost]
        public Customer Post(Customer customer)
        {
            //_customers.Add(customer);
            _customerService.InsertCustomer(customer);
            //_customerService.Insert(customer);
            return customer;
        }
    }
}
