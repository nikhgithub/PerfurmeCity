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
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
            }
        }
        private void BindProducts()
        {
            try
            {
                DataAccess dataAccess = new DataAccess();
                DataTable dtProducts = dataAccess.GetAllProducts();

                if (dtProducts != null && dtProducts.Rows.Count > 0)
                {
                    rptProducts.DataSource = dtProducts;
                    rptProducts.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log or show error message
            }
        }
    }
}