using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class NewYorkStore : AStore
    {
        public new string Name = "NewYorkStore";
        public NewYorkStore()
        {
            // Name = "NewYorkStore";
            // var customer = new Customer();
            // var pizza = new MeatPizza();
            // var order = new Order();
            // order.Store = "NewYorkStore";
            // order.Pizza = pizza;
            // order.Customer = customer;
            // orders = new List<Order> { order };
        }

        public override string ToString()
        {
            return Name;
        }
    }
}