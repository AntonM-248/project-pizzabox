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
            Console.WriteLine("Enter 1 if customer, 2 if store owner");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Run();
            }
            else
            {
                OwnerMenu();
            }
        }

        private static void OwnerMenu()
        {
            Console.WriteLine("Enter 1 for NY, 2 for Chicago");
            int num = int.Parse(Console.ReadLine());
            _storeSingleton.Stores[num - 1].printOrders();
        }

        private static void Run()
        {
            var order = new Order();

            Console.WriteLine("Welcome to PizzaBox");
            DisplayStoreMenu();

            order.Customer = new Customer();
            int num = 0;
            order.Store = SelectStore(ref num).Name;
            order.Pizzas = SelectPizza();
            Console.WriteLine($"Your total is ${order.GetPrice()}");
            Console.WriteLine($"{order.ToString()}");
            _storeSingleton.Stores[num].orders.Add(order);
            _storeSingleton.finish();
        }

        private static void DisplayOrder(APizza pizza)
        {
            Console.WriteLine($"Added to your order: {pizza}");
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

        private static List<APizza> SelectPizza()
        {
            List<APizza> pizzas = new List<APizza>();
            Console.WriteLine("Enter -1 to submit your order");
            int input = 0;
            while (input != -1)
            {
                input = int.Parse(Console.ReadLine());
                if (input != -1)
                {
                    var pizza = _pizzaSingleton.Pizzas[input - 1];
                    DisplayOrder(pizza);
                    pizzas.Add(pizza);
                }
            }
            return pizzas;
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