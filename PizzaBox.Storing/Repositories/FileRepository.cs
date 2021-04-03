using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PizzaBox.Storing.Repositories
{
    public class FileRepository
    {
        public bool WriteToFile(List<AStore> stores)
        {
            try
            {
                //you need:
                //access to path
                string path = @"PizzaBox.Storing/Repositories/store.xml"; //literal string
                //open file
                StreamWriter writer = new StreamWriter(path);
                //access to the object
                //class definition/structure
                XmlSerializer xml = new XmlSerializer(typeof(List<AStore>));
                //serialize (convert to markup[xml in this case, or xtensible markup lang])
                xml.Serialize(writer, stores);//this also writes
                //write to file
                //close file  
                return true;
            }
            // catch (FileNotFoundException e)
            // {
            //     throw new Exception($"Wrong file mate, {e}, {e.Message}");
            // }
            catch//catches all exceptions
            {
                return false;
                //don't do below because it is pointless. Add some context
                //throw;
            }
        }

        public List<T> ReadFromFile<T>(string path) where T : class
        {
            var reader = new StreamReader(path);
            //below converts to POCOs, plain old c# objects
            var xml = new XmlSerializer(typeof(List<T>));
            //returns null in case of error
            //preferrable to avoid requiring exception handles
            return xml.Deserialize(reader) as List<T>;
            //you can also do
            //return (List<AStore>) xml.Deserialize(reader);
            //if error returns class cast exception
        }
    }
}