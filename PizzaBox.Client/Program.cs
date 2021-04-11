using System;
using PizzaBox.Storing.Entities;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Client
{
    internal class Program
    {
        private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
        private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;

        private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;

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
            Console.WriteLine("Please enter your user id, or if you are a new user, enter your desired user id");
            string Name = Console.ReadLine();
            Customer Customer = _customerSingleton.FindCustomer(Name);
            Console.WriteLine("Enter 1 to place order, 2 to view order history");
            string response = Console.ReadLine();
            if (response == "1")
            {
                myDBContext context = new myDBContext();
                var order = new Order();
                Console.WriteLine("Welcome to PizzaBox");
                DisplayStoreMenu();
                order.Customer = new Customer();
                int num = 0;
                SelectStore(ref num);
                order.Store = _storeSingleton.Stores[num].Name;
                order.Pizzas = SelectPizza();
                Console.WriteLine($"Your total is ${order.GetPrice()}");
                Console.WriteLine($"{order.ToString()}");
                _storeSingleton.Stores[num].orders.Add(order);
                _storeSingleton.finish();
                _customerSingleton.AddOrder(order, Name);
                _customerSingleton.finish();

                var OH = new OrderHistory()
                {
                    StoreName = _storeSingleton.Stores[num].Name,
                    CustomerName = Name,
                    TotalPrice = (int)order.GetPrice(),
                };
                OH.SetPriceZero();
                context.Add(OH);
                context.SaveChanges();

            }
            else
            {
                Console.WriteLine(Customer.ToString());
            }
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
            Console.WriteLine("Enter -1 to submit your order, 3 for custom pizza");
            int input = 0;
            while (input != -1)
            {
                input = int.Parse(Console.ReadLine());
                if (input == 3)
                {
                    Console.WriteLine("Pick crust: 1 for thin $1, 2 for medium $2, 3 for thick $3");
                    int num = int.Parse(Console.ReadLine());
                    Console.WriteLine("Pick a size: 1 for small $6, 2 for medium $8, 3 for large $10");
                    int num2 = int.Parse(Console.ReadLine());
                    var pizza = new CustomPizza(num - 1, num2 - 1);
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("Pick a topping, each is $2: 1 for pineapple, 2 for mushrooms, 3 for spinach, \n4 for chicken, 5 for beef, -1 to finish adding toppings");
                        int j = int.Parse(Console.ReadLine());
                        if (j == -1)
                        {
                            i = 100;
                        }
                        else
                        {
                            pizza.AddTopping(j - 1);
                        }
                    }
                    pizzas.Add(pizza);
                }
                else if (input != -1)
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