using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client
{
    internal class Program
    {
        private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
        private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;

        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var order = new Order();

            Console.WriteLine("Welcome to PizzaBox");
            DisplayStoreMenu();

            order.Customer = new Customer();
            int num = 0;
            order.Store = SelectStore(ref num).Name;
            order.Pizza = SelectPizza();
            _storeSingleton.Stores[num].orders.Add(order);
            _storeSingleton.finish();
        }

        private static void DisplayOrder(APizza pizza)
        {
            Console.WriteLine($"Your order is: {pizza}");
        }

        private static void DisplayPizzaMenu()
        {
            var index = 0;

            foreach (var item in _pizzaSingleton.Pizzas)
            {
                Console.WriteLine($"{++index} - {item}");
            }
        }

        private static void DisplayStoreMenu()
        {
            var index = 0;

            foreach (var item in _storeSingleton.Stores)
            {
                Console.WriteLine($"{++index} - {item}");
            }
        }

        private static APizza SelectPizza()
        {
            var input = int.Parse(Console.ReadLine());
            var pizza = _pizzaSingleton.Pizzas[input - 1];

            DisplayOrder(pizza);

            return pizza;
        }

        private static AStore SelectStore(ref int num)
        {
            var input = int.Parse(Console.ReadLine()); // be careful (think exception/error handling)

            DisplayPizzaMenu();
            num = input - 1;
            return _storeSingleton.Stores[input - 1];
        }
    }
}