using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PerfurmeCity.MASTERPAGES
{
    public partial class MasterLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the search text from session and set it to the text box
                if (Session["SearchText"] != null)
                    txtsearchengine.Text = Session["SearchText"].ToString();
                // Check if user is logged in
                if (Session["IsLoggedIn"] != null && (bool)Session["IsLoggedIn"])
                {
                    // If user is logged in, display logout option
                    btnSignInSignUp.Text = "Logout";
                    // lnkSignInSignUp.NavigateUrl = "Home.aspx"; // Specify the logout page URL
                }
                else
                {
                    // If user is not logged in, display signin/signup option
                    btnSignInSignUp.Text = "SignIn-SigUp";
                    //Response.Redirect("~/UI/SigIn.aspx");
                    // lnkSignInSignUp.NavigateUrl = "#"; // Specify the signin/signup page URL
                }
                int userId = -1; // Default value
                if (Session["UserID"] != null)
                {
                    userId = Convert.ToInt32(Session["UserID"]);
                 
                    if(userId==1)
                    {
                        adimpanel.Visible = true;
                    }
                }


            }
            //if (btnSignInSignUp.Text = "SignIn-SigUp";)


        }

        protected void btnSignInSignUp_Click(object sender, EventArgs e)
        {
            if (btnSignInSignUp.Text == "Logout")
            {
                // Clear session or authentication cookies to log out the user
                Session.Clear(); // Clear all session variables
                Session.Abandon(); // 
                btnSignInSignUp.Text ="LogIn-Again?";
                Response.Redirect("~/UI/Home.aspx");
            }
            else
            {
                btnSignInSignUp.Text = "SignIn-SigUp";
                Response.Redirect("~/UI/SigIn.aspx");
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (txtsearchengine.Text != "")
            {
                // Store the search text in session
                Session["SearchText"] = txtsearchengine.Text;
                Response.Redirect("~/UI/SearchResults.aspx?searchParam=");
            }

        }
    }
}