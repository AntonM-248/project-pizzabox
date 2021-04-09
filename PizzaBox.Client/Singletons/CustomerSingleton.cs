using System.IO;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using System;

namespace PizzaBox.Client.Singletons
{

    public class CustomerSingleton
    {
        private static CustomerSingleton _instance;

        private static readonly FileRepository _fileRepository = new FileRepository();

        private const string _path = @"PizzaBox.Storing/Repositories/customer.xml";

        public List<Customer> Customers { set; get; }

        public static CustomerSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomerSingleton();
                }
                return _instance;
            }
        }

        private CustomerSingleton()
        {
            if (File.Exists(_path))
            {
                Customers = _fileRepository.ReadFromFile<Customer>(_path);
            }
            else
            {
                Customers = new List<Customer>();
            }
        }

        public void finish()
        {
            _fileRepository.WriteToFile<Customer>(Customers, _path);
        }


        public Customer FindCustomer(string Name)
        {
            foreach (Customer Customer in Customers)
            {
                if (Customer.Name == Name)
                {
                    return Customer;
                }
            }
            Customers.Add(new Customer(Name));
            foreach (Customer Customer in Customers)
            {
                if (Customer.Name == Name)
                {
                    return Customer;
                }
            }
            return new Customer(Name);
        }

        public void AddOrder(Order Order, string Name)
        {
            foreach (Customer Customer in Customers)
            {
                if (Customer.Name == Name)
                {
                    Customer.orders.Add(Order);
                }
            }
        }

    }
}