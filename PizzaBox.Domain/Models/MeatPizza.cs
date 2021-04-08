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
            Name = "MeatPizza";
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
        public override decimal GetPrice()
        {
            decimal result = 0;
            foreach (Topping top in Toppings)
            {
                result += top.Price;
            }
            result += Size.Price;
            result += Crust.Price;
            return result;
        }
    }
}