using ProductAPI.Models;

namespace ProductAPI.Services
{
    public class ProductRepo : IRepo<int, Product>
    {
        //static List<Product> _products = new List<Product>()
        //{
        //    new Product(){ Id = 1, Name = "Pizza", Price = 12.56, Quantity = 21},
        //    new Product(){ Id = 2, Name = "Dictionary", Price = 56.42, Quantity = 4},
        //    new Product(){ Id = 3, Name = "Laptop", Price = 502.24, Quantity = 7}
        //};
        
        private readonly SampleContext _context;

        public ProductRepo(SampleContext context)
        {
            _context = context;
        }
        public async Task<Product> Delete(int key)
        {
            var product = await Get(key);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return null;
        }

        public async Task<Product> Get(int key)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == key);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return _context.Products.ToList();
        }

        public async Task<Product> Insert(Product item)
        {
            //check product
            var product = await Get(item.Id);
            if (product == null)
            {
                _context.Products.Add(item);
                _context.SaveChanges();
            }
            else
            {
                product.Quantity += item.Quantity;
                _context.SaveChanges();
            }    
            return item;
        }

        public async Task<Product> Update(Product item)
        {
             var product = await Get(item.Id);
            if (product != null)
            {
                product.Price = item.Price;
                product.Quantity = item.Quantity;
                _context.SaveChanges();
                return product;
            }
            return null;
        }
    }
}
