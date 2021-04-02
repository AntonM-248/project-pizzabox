namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// Represents the pizza abstract class
    /// </summary>
    public abstract class AComponent
    {
        //fields   
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}