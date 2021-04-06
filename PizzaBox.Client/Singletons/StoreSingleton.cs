using System.IO;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using System;

namespace PizzaBox.Client.Singletons
{

    public class StoreSingleton
    {
        private static StoreSingleton _instance;

        private static readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"PizzaBox.Storing/Repositories/store.xml";
        public List<AStore> Stores { get; set; }

        public static StoreSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StoreSingleton();
                }
                return _instance;
            }
        }

        private StoreSingleton()
        {
            if (File.Exists(_path))
            {
                Stores = _fileRepository.ReadFromFile<AStore>(_path);
            }
            else
            {
                Stores = new List<AStore> { new ChicagoStore(), new NewYorkStore() };
            }
        }

        public void finish()
        {
            _fileRepository.WriteToFile<AStore>(Stores, _path);
        }
    }
}