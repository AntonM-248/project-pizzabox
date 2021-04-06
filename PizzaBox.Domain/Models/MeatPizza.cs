using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class MeatPizza : APizza
    {
        public MeatPizza()
        {

        }
        public MeatPizza(int n)
        {
            Size = new Size(2);
            Crust = new Crust(2);
            Toppings = new List<Topping>
            {
                    new Topping{
                        Name = "chicken",
                        Price = 2,
                    },
                    new Topping
                    {
                        Name = "beef",
                        Price = 2,
                    }
            };
        }

    }
}