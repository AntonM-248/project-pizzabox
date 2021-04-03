using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// Represents the store abstract class
    /// </summary>
    //these allow serializer to work with inheriting classes
    [XmlInclude(typeof(ChicagoStore))]
    [XmlInclude(typeof(NewYorkStore))]

    public abstract class AStore
    {
        //fields   
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}