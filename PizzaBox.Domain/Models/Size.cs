using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Size : AComponent
    {
        public Size(int n)
        {
            switch(n)
            {
                case 0:
                    Name = "small";
                    Price = 6;
                    break;
                case 1:
                    Name = "medium";
                    Price = 8;
                    break;
                case 2:
                    Name = "large";
                    Price = 10;
                    break;
            }
        }

        public Size()
        {

        }
    }
}