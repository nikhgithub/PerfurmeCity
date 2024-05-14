using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.NetworkInformation;
using PerfurmeCity.DATA;
using System.Xml.Linq;

namespace PerfurmeCity.UI
{
    public partial class ShippingAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataAccess dataAccess=new DataAccess();
                txtTotalPrice.Text = dataAccess.GetTotalPriceInCart(1).ToString("0.00");
                // Assuming userID is obtained from user authentication or session
                int userID = 1; // Replace with actual userID retrieval logic

                // Instantiate the DAL
                DataAccess orderDAL = new DataAccess();

                // Get address details for the user
                DataTable dtAddress = orderDAL.GetAddressDetails(userID);

                if (dtAddress.Rows.Count > 0)
                {
                    // Populate UI fields with address details
                    txtAddress1.Text = dtAddress.Rows[0]["Address1"].ToString();
                    txtAddress2.Text = dtAddress.Rows[0]["Address2"].ToString();
                    txtemailNumber.Text = dtAddress.Rows[0]["Email"].ToString();
                    txtPhoneNumber.Text = dtAddress.Rows[0]["Phone"].ToString();
                    txtCity.Text = dtAddress.Rows[0]["City"].ToString();
                    txtZip.Text = dtAddress.Rows[0]["ZipCode"].ToString();
                }
                else
                {
                    // Display empty fields for the user to enter new address details
                    txtAddress1.Text = "";
                    txtAddress2.Text = "";
                    txtemailNumber.Text = "";
                    txtPhoneNumber.Text = "";
                    txtCity.Text = "";
                    txtZip.Text = "";
                }
            }

        }
        //DESKTOP-BB9LET8

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.UpdateOrCreateAddress(1, txtAddress1.Text, txtAddress2.Text, txtemailNumber.Text, txtPhoneNumber.Text, txtCity.Text, ddlDeliveryMode.Text, txtZip.Text, "Texas");

            string orderID = dataAccess.GenerateOrderID();
            ScriptManager.RegisterStartupScript(this, GetType(), "showOrderIDPopup", "showOrderIDPopup('our team will contact you your order id" + orderID + "');", true);
        }
        // Method to generate the HTML email body
        private string GenerateEmailBody(string orderDetails)
        {
            // Here you can use your creativity to design the HTML email body
            string body = @"
                <html>
                <head>
                    <style>
                        /* Add your CSS styles here */
                    </style>
                </head>
                <body>
                    <h2>Order Confirmation</h2>
                    <p>Thank you for your order!</p>
                    <p>Order Details:</p>
                    <p>" + orderDetails + @"</p>
                </body>
                </html>";

            return body;
        }
    }
}