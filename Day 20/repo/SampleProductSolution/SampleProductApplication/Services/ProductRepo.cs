using SampleProductApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProductApplication.Services
{
    public class ProductRepo : IRepo<int, Product>
    {
        private readonly ShopContext _context; //Taking the context object as injection

        public ProductRepo(ShopContext context)
        {
            _context = context;
        }

        public ProductRepo()
        {
        }

        public bool Add(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
            return true;
        }

        public virtual Product Get(int id)
        {
            Product Product = _context.Products.FirstOrDefault(x => x.Id == id);
            return Product;
        }

        public virtual Product GetByName(string name)
        {
            Product Product = _context.Products.FirstOrDefault(x => x.Name == name);
            return Product;
        }

        public ICollection<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public bool Remove(int id)
        {
            Product Product = Get(id);
            if (Product != null)
            {
                _context.Products.Remove(Product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Product item)
        {
            Product Product = _context.Products.FirstOrDefault(x => x.Id == item.Id);
            if (Product != null)
            {
                Product.Name = item.Name;
                Product.Category = item.Category;
                Product.Price = item.Price;
                Product.Quantity = item.Quantity;
                Product.Pic = item.Pic;
                Product.Description = item.Description;
                _context.Products.Update(Product);
                _context.SaveChanges();
                return true;

                //Product(Id, Name, Category, Price, Quantity, Pic, Description)
            }
            return false;

        }
    }
}
