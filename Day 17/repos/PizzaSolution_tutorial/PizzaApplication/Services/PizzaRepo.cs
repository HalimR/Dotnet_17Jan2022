using PizzaApplication.Models;

namespace PizzaApplication.Services
{
    public class PizzaRepo : IRepo<int, Pizza>
    {
        static List<Pizza> Pizzas = new List<Pizza>()
        {
            new Pizza()
            {
                Id = 1,
                Name ="ABC",
                IsVeg = true,
                Price = 12.4,
                //Pic = "/images/Pizza1.jpg",
                //Details = "a dish of Italian origin consisting of a usually round, flat base of leavened wheat-based dough topped with tomatoes, cheese, and often various other ingredients (such as anchovies, mushrooms, onions, olives, pineapple, meat, etc.),"
            },
             new Pizza()
            {
                Id = 2,
                Name ="BBB",
                IsVeg = false,
                Price = 45.7,
                //Pic = "/images/Pizza2.jpg",
                //Details = "a dish of Italian origin consisting of a usually round, flat base of leavened wheat-based dough topped with tomatoes, cheese, and often various other ingredients (such as anchovies, mushrooms, onions, olives, pineapple, meat, etc.),"
            }
        };
        public bool Add(Pizza t)
        {
            Pizzas.Add(t);
            return true;
        }

        public bool Delete(int k)
        {
            try
            {
                Pizzas.Remove(Pizzas.Find(p => p.Id == k));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public ICollection<Pizza> GetAll()
        {
            return Pizzas;
        }

        public Pizza GetT(int k)
        {
            var pizza = Pizzas.FirstOrDefault(p => p.Id == k);
            return pizza;
        }

        public bool Update(int k, Pizza t)
        {
            var MyPizza = Pizzas.FirstOrDefault(p => p.Id == k);
            if (MyPizza != null)
            {
                MyPizza.Name = t.Name;
                MyPizza.Price = t.Price;
                MyPizza.IsVeg = t.IsVeg;
                return true;
            }
            return false;
        }
    }
}