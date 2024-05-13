using PerfurmeCity.DATA;
using PerfurmeCity.MODELS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PerfurmeCity.UI
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCartItems();
                LoadRecommendations(1);
            }

        }
        private void LoadCartItems()
        {
            DataAccess dataAccess = new DataAccess();
            // Assuming you have a session variable for the current user ID
            string userID = "1";

            if (!string.IsNullOrEmpty(userID))
            {
                // Call the data access layer method to retrieve cart details for the user
                List<CartDetail> cartItems = dataAccess.GetCartDetailsByUserID(1);

                // Bind the cart items to the Repeater
                rptCartItems.DataSource = cartItems;
                rptCartItems.DataBind();
            }
        }

        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ShippingAddress.aspx");
        }
        private void LoadRecommendations(int userid)
        {
            DataAccess dataAccess = new DataAccess();
            DataTable recommendedProducts = new DataTable();
            List<CartDetail> cartItems = dataAccess.GetCartDetailsByUserID(1);
            // Check if there are any cart items
            if (cartItems.Count > 0)
            {
                // Get the first cartId from the cartItems list
                int firstCartId = cartItems[0].CartDetailID;

                // Call the ExecuteQueryForRecommendation method with the firstCartId
                recommendedProducts = dataAccess.ExecuteQueryForRecommendation(firstCartId);
                // Bind the DataTable to the Repeater control
                rptRecommendedProducts.DataSource = recommendedProducts;
                rptRecommendedProducts.DataBind();
            }
            else
            {
                // Handle case where there are no cart items
                Console.WriteLine("No cart items found.");
            }


        }

    }
}