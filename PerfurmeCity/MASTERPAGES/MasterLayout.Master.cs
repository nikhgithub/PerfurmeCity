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