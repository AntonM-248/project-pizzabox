using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Crust : AComponent
    {
        public Crust()
        {

        }

        public Crust(int n)
        {
            switch (n)
            {
                case 0:
                    Name = "thinCrust";
                    Price = 1;
                    break;
                case 1:
                    Name = "mediumCrust";
                    Price = 2;
                    break;
                case 2:
                    Name = "thickCrust";
                    Price = 3;
                    break;
            }
        }
    }
}