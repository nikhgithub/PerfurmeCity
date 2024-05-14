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
    public partial class ProductsByGender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string gender = Request.QueryString["gender"];
                if (!string.IsNullOrEmpty(gender))
                {
                    BindIngredients(gender);
                }
            }
        }
        private void BindIngredients(string gender)
        {
            DataAccess ingredientDAL = new DataAccess();
            DataTable dtIngredients = ingredientDAL.GetIngredientsByGender(gender);
            rptIngredients.DataSource = dtIngredients;
            rptIngredients.DataBind();
        }
    }
}