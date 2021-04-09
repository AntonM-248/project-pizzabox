using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// Represents the pizza abstract class
    /// </summary>
    [XmlInclude(typeof(MeatPizza))]
    [XmlInclude(typeof(VeganPizza))]
    [XmlInclude(typeof(CustomPizza))]
    public abstract class APizza
    {
        //fields   
        public string Name;
        public Crust Crust;
        public Size Size;

        public abstract decimal GetPrice();
        public List<Topping> Toppings;

        public override string ToString()
        {
            return $"{Name} ${GetPrice()}";
        }
    }
}