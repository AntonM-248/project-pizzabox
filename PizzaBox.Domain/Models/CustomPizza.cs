using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class CustomPizza : APizza
    {
        public CustomPizza()
        {

        }
        public CustomPizza(int x, int y)
        {
            Name = "CustomPizza";
            Crust = new Crust(x);
            Size = new Size(y);
            Toppings = new List<Topping>();
        }

        public void AddTopping(int n)
        {
            Toppings.Add(new Topping(n));
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
