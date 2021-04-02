using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Singletons
{

    public class StoreSingleton
    {
        private static StoreSingleton _instance;

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
            Stores = new List<AStore>
            {
                new NewYorkStore(),
                new ChicagoStore(),
            };
        }

        public void WriteToFile()
        {
            //you need:
            //access to path
            string path = @"store.xml"; //literal string
            //open file
            StreamWriter writer = new StreamWriter(path);
            //access to the object
            var stores = Stores;
            //class definition/structure
            XmlSerializer xml = new XmlSerializer(typeof(List<AStore>));
            //serialize (convert to markup[xml in this case, or xtensible markup lang])
            xml.Serialize(writer, stores);//this also writes
            //write to file
            //close file   
            writer.Close();
        }

        //how to read
        //writer -> reader
        // serialize -> deserialize 
    }
}