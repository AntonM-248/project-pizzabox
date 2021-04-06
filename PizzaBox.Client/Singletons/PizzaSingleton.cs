using System.Collections.Generic;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{

    public class PizzaSingleton
    {
        private static PizzaSingleton _instance;

        public List<APizza> Pizzas { get; set; }

        public static PizzaSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PizzaSingleton();
                }
                return _instance;
            }
        }

        private PizzaSingleton()
        {
            Pizzas = new List<APizza>
            {
                new MeatPizza(1),
                new VeganPizza(1),
            };
        }

        // public static StoreSingleton Instance()
        // {
        //     if (_instance == null)
        //     {
        //         _instance = new StoreSingleton();
        //     }
        //     return _instance;
        // }
    }
}