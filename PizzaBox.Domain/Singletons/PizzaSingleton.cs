using System.Collections.Generic;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Singletons
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
                new MeatPizza(),
                new VeganPizza(),
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