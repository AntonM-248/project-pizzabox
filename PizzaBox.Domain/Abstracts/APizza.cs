using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// Represents the pizza abstract class
    /// </summary>
    public abstract class APizza
    {
        //fields   
        public Crust Crust { get; set; }
        public Size Size { get; set; }

        public List<Topping> Toppings { get; set; }
    }
}