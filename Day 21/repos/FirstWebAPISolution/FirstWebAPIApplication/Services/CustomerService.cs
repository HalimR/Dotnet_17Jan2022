namespace FirstWebAPIApplication.Services
{
    public class CustomerService :ICustomerService
    {
        private readonly IRepo<int, Customer> _customerRepo;

        public CustomerService(IRepo<int, Customer>  customerRepo)
        {
            this._customerRepo = customerRepo;
        }

        public void DeleteCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer");

            _customerRepo.Delete(customer);
        }

        public ICollection<Customer> GetAllCustomer()
        {
            return _customerRepo.GetAll().ToList();
        }

        public Customer GetCustomerById(int custId)
        {
            Customer customer = _customerRepo.Get(custId);
            return customer;
        }

        public void InsertCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer");

            _customerRepo.Insert(customer);

        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer");

            _customerRepo.Update(customer);
        }
    }
}
