using System.Text;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Customer
    {
        public string Name;
        public List<Order> orders;
        public Customer()
        {
            orders = new List<Order>();
        }

        public Customer(string Name)
        {
            this.Name = Name;
            orders = new List<Order>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Order Order in orders)
            {
                sb.Append($"{Order.ToString()}\n");
            }
            return sb.ToString();
        }
    }
}