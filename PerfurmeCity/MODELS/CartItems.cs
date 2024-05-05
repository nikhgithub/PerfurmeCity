using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerfurmeCity.MODELS
{
    public class CartItems
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string UserID { get; set; }
    }
}