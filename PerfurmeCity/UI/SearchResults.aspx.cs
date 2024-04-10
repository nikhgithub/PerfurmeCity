using PerfurmeCity.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
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
                if (!string.IsNullOrEmpty(Request.QueryString["paramName"]) )
                {
                    // Retrieve the value of the query string parameter
                    paramValue = Request.QueryString["paramName"];

                    getsearchresults(paramValue);
                    // Now you can use paramValue in your code
                    // For example, you can set it as the text of a label

                }

                TextBox txtSearch = (TextBox)Master.FindControl("txtSearchEngine");

                getsearchresults(txtSearch.Text);

            }
           
        }

        protected void getsearchresults(string searchparams)
        {
            DataTable dtsearchresults = new DataTable();
            ProductDAL getproducts = new ProductDAL();
            dtsearchresults = getproducts.searchResults(searchparams);
            for (int i = 0; i < dtsearchresults.Rows.Count; i++)
            {
                // Generate HTML markup for each card
                string cardHtml = $@"
            <div class='card'>
                <div class='card-body'>
                    <h5 class='card-title'>Card Title {i + 1}</h5>
                    <p class='card-text'>Description goes here...</p>
                </div>
            </div>";

                // Add the HTML markup to the card container
                cardContainer.InnerHtml += cardHtml;
            }



        }

    }
}