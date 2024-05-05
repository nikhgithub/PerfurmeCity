using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace PerfurmeCity.MODELS
{
    public class Ingridients
    {
        public int IngridientsID { get; set; }
        public string IngridientsName { get; set; }
        public string IngridientsDescription { get; set; }

        public decimal IngridientsPrice { get; set; }

        public string Ingridientstags { get; set; }

        public decimal IngridientsDiscount { get; set; }

        public string IngridientsGender { get; set; }

        public string IngridientsImageURL { get; set; }

        public string IngridientsCreatedDate {  get; set; }

        public bool IngridientsIsActive { get; set; }

    }

}