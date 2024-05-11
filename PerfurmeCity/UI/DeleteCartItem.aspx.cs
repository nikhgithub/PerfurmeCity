using PerfurmeCity.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PerfurmeCity.UI
{
    public partial class DeleteCartItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the request is a postback and if the cartDetailID parameter is present
            if (Request.RequestType == "POST" && Request.Form["cartDetailID"] != null)
            {
                // Get the cartDetailID parameter from the request
                int cartDetailID;
                if (int.TryParse(Request.Form["cartDetailID"], out cartDetailID))
                {
                    // Call the method to delete the cart item by ID
                    DeleteCartItemByID(cartDetailID);
                }
                else
                {
                    // Invalid cartDetailID format
                    Response.StatusCode = 400; // Bad Request
                    Response.End();
                }
            }
            else
            {
                // No valid request or parameter provided
                Response.StatusCode = 400; // Bad Request
                Response.End();
            }
        }

        private void DeleteCartItemByID(int cartDetailID)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.DeleteCartDetail(cartDetailID);
            dataAccess.GetCartDetailsByUserID(1);
            dataAccess.DeleteCartDetail(cartDetailID);
            Response.StatusCode = 200; // OK
            Response.End();
        }
    }
}