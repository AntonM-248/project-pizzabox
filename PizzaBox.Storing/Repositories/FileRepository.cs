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
        public bool WriteToFile<T>(List<T> items, string path) where T : class
        {
            // try
            // {
            //you need:
            //access to path
            //open file
            StreamWriter writer = new StreamWriter(path);
            //access to the object
            //class definition/structure
            XmlSerializer xml = new XmlSerializer(typeof(List<T>));
            //serialize (convert to markup[xml in this case, or xtensible markup lang])
            xml.Serialize(writer, items);//this also writes
                                         //write to file
                                         //close file  
            writer.Close();
            Console.WriteLine("Wrote stuff");
            return true;
            // }
            // catch (FileNotFoundException e)
            // {
            //     throw new Exception($"Wrong file mate, {e}, {e.Message}");
            // }
            // catch//catches all exceptions
            // {
            //     Console.WriteLine("Failed to write");
            //     return false;
            //don't do below because it is pointless. 
            //forces calling function to also trycatch
            //Add some context
            //throw;
            //
        }

        public List<T> ReadFromFile<T>(string path) where T : class
        {
            var reader = new StreamReader(path);
            //below converts to POCOs, plain old c# objects
            var xml = new XmlSerializer(typeof(List<T>));
            //returns null in case of error
            //preferrable to avoid requiring exception handles
            List<T> result = xml.Deserialize(reader) as List<T>;
            reader.Close();
            return result;
            //you can also do
            //return (List<AStore>) xml.Deserialize(reader);
            //if error returns class cast exception
        }
    }
}