using Microsoft.AspNetCore.Mvc;
using SampleAPIFEApplication.Models;
using SampleAPIFEApplication.Services;

namespace SampleAPIFEApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepo<int, Product> _repo;

        public ProductController(IRepo<int, Product> repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                string token = HttpContext.Session.GetString("token");

                _repo.GetToken(token);
                var products = await _repo.GetAll();
                return View(products);
            }
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            var prod = await _repo.Insert(product);
            if (prod == null)
                return View();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            var prod = await _repo.Get(id);
            return View(prod);
        }
        
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var prod = await _repo.Get(id);
            return View(prod);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Product prod)
        {
            try
            {
                await _repo.Update(prod);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
