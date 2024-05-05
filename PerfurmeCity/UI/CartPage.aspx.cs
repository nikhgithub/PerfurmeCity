using PerfurmeCity.DATA;
using PerfurmeCity.MODELS;
using System;
using System.Collections.Generic;
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

    }
}