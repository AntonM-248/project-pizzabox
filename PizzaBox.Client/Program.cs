using System.Collections.Generic;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

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
            var stores = new List<AStore>()
            {
                new NewYorkStore(),
                new ChicagoStore(),
            };
            foreach (var item in stores)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
