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

        protected APizza()
        {
            Factory();
        }
        //constructor is doing factory method but usually it is separate
        //and constructor calls factory method
        private void Factory()
        {
            Toppings = new List<Topping>();

            AddCrust();
            AddSize();
            AddToppings();
        }

        public virtual void AddCrust()
        {
            Crust = new Crust();
        }

        public virtual void AddSize()
        {
            Size = new Size();
        }

        public abstract void AddToppings();
    }
}