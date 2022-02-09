using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AssignmentD16Application.Models;

namespace AssignmentD16Application.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> Products = new List<Product>()
        {
            new Product()
            {
                  Id = 1,
                Name = "Test",
                Price = 45.10,
                SupplierId = 1,
                Quantity = 10,
                Remarks = "new"
            },
             new Product()
            {
                  Id = 2,
                Name = "Book",
                Price = 125.40,
                SupplierId = 1,
                Quantity = 2,
                Remarks = "sale"
            }
        };
        // GET: ProductController
        public ActionResult Index()
        {
            var products = Products;
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            Product productEdit = Products.Single(x => x.Id == id);
            return View(productEdit);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Products.Add(product);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product productEdit = Products.Single(x => x.Id == id);
            return View(productEdit);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, Product product)
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Product productEdit = Products.Single(x => x.Id == product.Id);
                    productEdit.Name = product.Name;
                    productEdit.Price = product.Price;
                    productEdit.SupplierId = product.SupplierId;
                    productEdit.Quantity = product.Quantity;
                    productEdit.Remarks = product.Remarks;
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
