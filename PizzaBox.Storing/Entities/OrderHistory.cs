using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    public partial class OrderHistory
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string CustomerName { get; set; }
        public int TotalPrice { get; set; }

        public void SetPriceZero()
        {
            TotalPrice = 0;
        }
    }
}
