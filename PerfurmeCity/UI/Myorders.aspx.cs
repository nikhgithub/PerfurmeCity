using PerfurmeCity.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PerfurmeCity.UI
{
    public partial class Myorders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userId = -1; // Default value
            if (Session["UserID"] != null)
            {
                userId = Convert.ToInt32(Session["UserID"]);
                DataAccess dataAccess=new DataAccess();
                rptOrders.DataSource = dataAccess.GetMyOrders(userId);
                rptOrders.DataBind();
            }

           
        }
    }
}