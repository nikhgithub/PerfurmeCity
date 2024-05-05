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
        DataTable dtsearchresults = new DataTable();
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
                string imageUrl = row["ImageUrl"].ToString();  // Assuming the image URL is stored in this column
                sb.Append($@"
                <div class='card' style='width: 18rem;'>
                     <asp:Image runat=""server"" ImageUrl={imageUrl} class='card-img-top' alt='Product image' />
                    <div class='card-body'>
                        <h5 class='card-title'>{productName}</h5>
                        <p class='card-text'>{description}</p>
                        <p class='card-text'><small class='text-muted'>Tags: {tags}</small></p>
                        <p class='card-text'>Price: ${price}</p>
                        <button class='btn btn-primary' onclick='addToCart({i})'>Add to Cart</button>
                    </div>
                </div>");
            }

            cardContainer.InnerHtml = sb.ToString();

        }


        // Method to filter search results based on price range
        private static DataTable FilterSearchResultsByPrice(string priceRange)
        {
            // Convert priceRange string to min and max values
            string[] priceRangeValues = priceRange.Split('-');
            decimal minPrice = Convert.ToDecimal(priceRangeValues[0]);
            decimal maxPrice = Convert.ToDecimal(priceRangeValues[1]);

            // Filter search results DataTable based on the provided price range
            DataTable dtFilteredResults = new DataTable();
            DataTable dtsearchresults = new DataTable();
            //ProductDAL getproducts = new ProductDAL();

            //dtsearchresults = getproducts.searchResults(searchparams);
            foreach (DataRow row in dtsearchresults.Rows)
            {
                decimal productPrice = Convert.ToDecimal(row["Price"]);
                if (productPrice >= minPrice && productPrice <= maxPrice)
                {
                    dtFilteredResults.ImportRow(row);
                }
            }

            return dtFilteredResults;
        }

        // Method to generate HTML for search results
        private static string GenerateHTMLForSearchResults(DataTable searchResults)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            foreach (DataRow row in searchResults.Rows)
            {
                // Assuming the DataTable contains columns like ProductName, Description, Price
                string productName = row["ProductName"].ToString();
                string description = row["Description"].ToString();
                decimal price = Convert.ToDecimal(row["Price"]);

                // Generate HTML for each card
                htmlBuilder.Append("<div class='card'>");
                htmlBuilder.Append($"<h5 class='card-title'>{productName}</h5>");
                htmlBuilder.Append($"<p class='card-text'>{description}</p>");
                htmlBuilder.Append($"<p class='card-text'>Price: ${price}</p>");
                htmlBuilder.Append("</div>");
            }

            return htmlBuilder.ToString();
        }



    }
}