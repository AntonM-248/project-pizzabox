using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Order
    {
        public string Store { get; set; }
        public Customer Customer { get; set; }
        public List<APizza> Pizzas { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal GetPrice()
        {
            decimal result = 0;
            foreach (APizza pizza in Pizzas)
            {
                result += pizza.GetPrice();
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (APizza pizza in Pizzas)
            {
                sb.Append($"{pizza},");
            }
            return sb.ToString();
        }
    }
}