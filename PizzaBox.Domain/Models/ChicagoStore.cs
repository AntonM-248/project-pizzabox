using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class ChicagoStore : AStore
    {
        public ChicagoStore()
        {
            Name = "ChicagoStore";
            // var customer = new Customer();
            // var pizza = new MeatPizza();
            // var order = new Order();
            // order.Store = "ChicagoStore";
            // order.Pizza = pizza;
            // order.Customer = customer;
            // orders = new List<Order> { order };
        }
        public override string ToString()
        {
            return $"This is Chitown - {Name}";
        }
    }
}