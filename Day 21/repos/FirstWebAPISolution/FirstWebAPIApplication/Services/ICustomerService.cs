namespace FirstWebAPIApplication.Services
{
    public interface ICustomerService
    {
        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void InsertCustomer(Customer customer);
        Customer GetCustomerById(int custId);
        ICollection<Customer> GetAllCustomer();
    }
}
