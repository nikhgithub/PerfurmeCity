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
              
            }

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (txtsearchengine.Text != "")
            {
                string searchParam = txtsearchengine.Text; // Replace this with your actual search parameter
                Response.Redirect("~/UI/SearchResults.aspx?searchParam=" + searchParam);
            }
          
        }
    }
}