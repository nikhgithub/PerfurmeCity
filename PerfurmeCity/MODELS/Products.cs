using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace PerfurmeCity.MODELS
{
    public class Products
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public string prodcutDescription { get; set; }

        public decimal ProductPrice { get; set; }

        public string Producttags { get; set; }

        public decimal ProductDiscount { get; set; }

        public string ProductGender { get; set; }

        public string productImageURL { get; set; }

        public string productCreatedDate {  get; set; }

        public bool productIsActive { get; set; }



    }

}