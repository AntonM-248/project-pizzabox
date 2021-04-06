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
        public APizza Pizza { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {

        }
    }
}