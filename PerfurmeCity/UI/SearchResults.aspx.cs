using PerfurmeCity.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PerfurmeCity.UI
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string paramValue = "";
                if (Session["SearchText"] != null)
                {
                    // Retrieve the value of the query string parameter
                    paramValue = Session["SearchText"].ToString();

                    getsearchresults(paramValue);
                    // Now you can use paramValue in your code
                    // For example, you can set it as the text of a label

                }
                
            }

        }

        protected void getsearchresults(string searchparams)
        {
            DataTable dtsearchresults = new DataTable();
            ProductDAL getproducts = new ProductDAL();
            dtsearchresults = getproducts.searchResults(searchparams);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dtsearchresults.Rows.Count; i++)
            {
                DataRow row = dtsearchresults.Rows[i];
                string productName = row["ProductName"].ToString();
                string description = row["Description"].ToString();
                string tags = row["Tags"].ToString();
                string price = row["Price"].ToString();

                sb.Append($@"
<div class='card'>
    <div class='card-body'>
        <h5 class='card-title'>{productName}</h5>
        <p class='card-text'>{description}</p>
        <p class='card-text'><small class='text-muted'>Tags: {tags}</small></p>
        <p class='card-text'>Price: ${price}</p>
    </div>
</div>");
            }

            cardContainer.InnerHtml = sb.ToString();


        }
        [WebMethod]
        public static int AddToCart(string productId)
        {
            List<string> cart;
            if (HttpContext.Current.Session["Cart"] == null)
            {
                cart = new List<string>();
            }
            else
            {
                cart = (List<string>)HttpContext.Current.Session["Cart"];
            }
            cart.Add(productId);
            HttpContext.Current.Session["Cart"] = cart;

            return cart.Count;
        }


    }
}