using Microsoft.AspNetCore.Mvc;
using PizzaApplication.Models;

namespace PizzaApplication.Controllers
{
    public class PizzaController : Controller
    {
        static List<Pizza> Pizzas = new List<Pizza>()
        {
            new Pizza()
            {
                Id = 1,
                Name ="ABC",
                IsVeg = true,
                Price = 12.4
            },
             new Pizza()
            {
                Id = 2,
                Name ="BBB",
                IsVeg = false,
                Price = 45.7
            }
        };

        public IActionResult Index()
        {
            var pizzas = Pizzas;
            return View(pizzas);
        }

        //[HttpPost]
        //public IActionResult Create(IFormCollection keyValues) //this doesnt require model at Create.cshtml
        //{
        //    Pizza pizza = new Pizza();
        //    pizza.Id = Convert.ToInt32(keyValues["id"].ToString());
        //    pizza.Name = keyValues["name"].ToString();
        //    pizza.Price = Convert.ToDouble(keyValues["price"].ToString());
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            Pizzas.Add(pizza);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Pizza pizzaSelect = Pizzas.FirstOrDefault(p => p.Id == id);
            return View(pizzaSelect);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Pizza pizzaSelect = Pizzas.FirstOrDefault(p => p.Id == id);
            return View(pizzaSelect);
        }

        [HttpPost]
        public IActionResult Edit(int id, Pizza pizza)
        {
            Pizza pizzaSelect = Pizzas.FirstOrDefault(p => p.Id == id);
            pizzaSelect.Name = pizza.Name;  
            pizzaSelect.Price = pizza.Price;
            pizzaSelect.IsVeg = pizza.IsVeg;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Pizza pizzaSelect = Pizzas.FirstOrDefault(p => p.Id == id);
            return View(pizzaSelect);
        }

        [HttpPost]
        public IActionResult Delete(int id, Pizza pizza)
        {
            Pizza pizzaSelect = Pizzas.FirstOrDefault(p => p.Id == id);
            Pizzas.Remove(pizzaSelect);
            return RedirectToAction("Index");
        }
    }
}
