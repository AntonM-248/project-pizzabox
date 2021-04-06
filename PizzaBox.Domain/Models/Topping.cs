using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Topping : AComponent
    {
        public Topping()
        {

        }

        public Topping(int n)
        {
            Price = 2;

            switch (n)
            {
                case 0:
                    Name = "pineapple";
                    break;
                case 1:
                    Name = "mushrooms";
                    break;
                case 2:
                    Name = "spinach";
                    break;
                case 3:
                    Name = "chicken";
                    break;
                case 4:
                    Name = "beef";
                    break;
            }
        }
    }
}