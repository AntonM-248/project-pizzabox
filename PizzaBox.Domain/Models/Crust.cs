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
            switch(n)
            {
                case 0:
                    Name = "thin";
                    Price = 1;
                    break;
                case 1:
                    Name = "medium";
                    Price = 2;
                    break;
                case 2:
                    Name = "thick";
                    Price = 3;
                    break;
            }
        }
    }
}