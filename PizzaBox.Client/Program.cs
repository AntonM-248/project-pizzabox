using System.Collections.Generic;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;

namespace PizzaBox.Client
{
    class Program
    {
        private static void Main(string[] args)
        {
            //var is useful here because Program() handles instantiation
            //and can more easily be changed later
            //ie var p = new App();
            var p = new Program();
            p.Run();
            //Static methods can be called without instantiating an obj
            StaticRun();
            string a = "Jon Jon";
            a = p.give();
            //System.Console.WriteLine(a);
        }

        private string give()
        {
            return "King Kong";
        }

        private void Run()
        {

        }

        private static void StaticRun()
        {
            System.Console.WriteLine("Welcome to PizzaBox");
            var store = StoreSingleton.Instance;

            var pizzas = PizzaSingleton.Instance;

            foreach (var item in store.Stores)
            {
                System.Console.WriteLine(item.Name);
            }
            store.WriteToFile();
            foreach (var item in pizzas.Pizzas)
            {
                System.Console.WriteLine($"{item.Crust} {item.Size}");
            }
        }
    }
}
