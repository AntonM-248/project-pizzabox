using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class ChicagoStore : AStore
    {
        public ChicagoStore()
        {
            Name = "ChicagoStore";
        }
        public override string ToString()
        {
            return $"This is Chitown - {Name}";
        }
    }
}