using SampleProductApplication.Models;

namespace SampleProductApplication.Services
{
    public class ProductService
    {
        private readonly IRepo<int, Product> _repo;

        public ProductService(IRepo<int, Product> repo)
        {
            _repo = repo;
        }
        public Product ProductCheck(Product product)
        {
            var myProd = _repo.Get(product.Id);
            if (myProd != null)
            {
                return product;
            }
            return null;
        }

        public Product ProductAdd(Product product)
        {
            var myProd = _repo.Add(product);
            if (myProd == true)
            {
                return product;
            }
            return null;
        }
    }
}
