using FirstWebAPIApplication.Models;

namespace FirstWebAPIApplication.Services
{
    public class CustomerRepo : IRepo<int, Customer>
    {
        private readonly ProjectContext _context; 

        public CustomerRepo(ProjectContext context)
        {
            _context = context;
        }
        public bool Insert(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();
            return true;
        }

        public Customer Get(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            return customer;
        }

        public Customer GetByName(string name)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.Name == name);
            return customer;
        }

        public ICollection<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public bool Delete(Customer item)
        {
            Customer customer = Get(item.Id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Customer item)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.Id == item.Id);
            if (customer != null)
            {
                customer.Name = item.Name;
                customer.Age = item.Age;
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public Customer GetById(object id)
        {
            throw new NotImplementedException();
        }
        
    }
}
