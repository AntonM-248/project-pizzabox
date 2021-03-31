using System.Collections.Generic;

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
        }

        private void Run()
        {

        }

        private static void StaticRun()
        {
            System.Console.WriteLine("Welcome to PizzaBox");
            var stores = new List<string>()
            {
                "Store 001",
                "Store 002",
                "Store 003",
            };
            foreach (var item in stores)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
