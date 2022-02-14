using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleProductApplication.Models;
using SampleProductApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProductApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepo<int, Product> _repo;
        public ProductController(IRepo<int, Product> repo)
        {
            this._repo = repo;
        }
        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public IActionResult List()
        {
            return View(_repo.GetAll());
        }

        public IActionResult Details(int id)
        {
            Product product = _repo.Get(id);
            if (TempData["buyQty"] != null)
            {
                TempData.Keep("buyQty");
                product.BuyQty = (int)TempData["buyQty"];
            }
            product.TotalPrice = product.Price * product.Quantity;
            return View(product);
        }

        [HttpPost]
        public IActionResult Buying(int id)
        {
            Product product = _repo.Get(id);
            product.TotalPrice = product.Price * product.Quantity;
            return View(product);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Category = GetProductCategory();
            ViewBag.Picture = GetProductPicture();
            Product product = _repo.Get(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            _repo.Update(product);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewBag.Category = GetProductCategory();
            ViewBag.Picture = GetProductPicture();
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _repo.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(int id, Product product)
        {
            _repo.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult BuyProduct(int id)
        {
            ViewBag.Category = GetProductCategory();
            ViewBag.Picture = GetProductPicture();
            Product product = _repo.Get(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult BuyProduct(int id, Product item)
        {
            Product product = _repo.Get(id);
            product.Quantity = product.Quantity - item.BuyQty;
            _repo.Update(product);
            if (TempData.ContainsKey("buyQty"))
            {
                TempData.Remove("buyQty");
            }
            TempData.Add("buyQty", item.BuyQty);
            return RedirectToAction("Details", "Product", new { id = product.Id });
        }

        //public IActionResult BuyDetails(int id)
        //{
        //    Product product = _repo.Get(id);
        //    product.TotalPrice = product.Price * product.BuyQty;
        //    return View(product);
        //}

        IEnumerable<SelectListItem> GetProductCategory()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem { Text = "Food", Value = "food" });
            categories.Add(new SelectListItem { Text = "Toy", Value = "toy" });
            categories.Add(new SelectListItem { Text = "Clothing", Value = "clothing" });
            return categories;
        }

        IEnumerable<SelectListItem> GetProductPicture()
        {
            List<SelectListItem> pictures = new List<SelectListItem>();
            pictures.Add(new SelectListItem { Text = "Food", Value = "images/food.jpg" });
            pictures.Add(new SelectListItem { Text = "Toy", Value = "images/toy.jpg" });
            pictures.Add(new SelectListItem { Text = "Clothing", Value = "images/clothing.jpg" });
            return pictures;
        }
    }
}
