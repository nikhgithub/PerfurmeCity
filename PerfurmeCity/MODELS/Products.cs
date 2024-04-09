using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace PerfurmeCity.MODELS
{
    public class Products
    {
        public string productName { get; set; }
        public string prodcutDescription { get; set; }

        public SqlMoney ProductPrice { get; set; }

        public string Producttags { get; set; }

        public float ProductDiscount { get; set; }

        public string ProductSpecifcs { get; set; }

        public string productServerImage { get; set; }

    }

}