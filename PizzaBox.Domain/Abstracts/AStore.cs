using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// Represents the store abstract class
    /// </summary>
    //these allow serializer to work with inheriting classes
    [XmlInclude(typeof(ChicagoStore))]
    [XmlInclude(typeof(NewYorkStore))]

    public abstract class AStore
    {
        //fields   
        public string Name { get; set; }

        public List<Order> orders = new List<Order>();

        public void AddOrder(Order order)
        {
            Order temp = new Order();
            temp = order;
            orders.Add(temp);
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public void printOrders()
        {
            foreach (Order order in orders)
            {
                System.Console.WriteLine(order.ToString());
            }
        }
    }
}