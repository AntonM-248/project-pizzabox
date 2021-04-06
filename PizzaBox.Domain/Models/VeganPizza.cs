using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class VeganPizza : APizza
    {
        public VeganPizza()
        {
            
        }

        public VeganPizza(int n)
        {
            Toppings = new List<Topping>{
                    new Topping{
                        Name = "spinach",
                        Price = 2,
                    },
                    new Topping{
                        Name = "mushrooms",
                        Price = 2,
                    },
                    new Topping{
                        Name = "pineapple",
                        Price = 2,
                    }
            };
        }
    }
}