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
    public partial class IngridentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ingredientsID = Request.QueryString["IngredientsID"];
                if (!string.IsNullOrEmpty(ingredientsID))
                {
                    // Now you have the IngredientsID, you can use it to fetch and display the details of the ingredient
                    // For example:
                    DataAccess dataAcces = new DataAccess();
                    DataTable dtIngredient = dataAcces.GetIngredientDetailsByID(ingredientsID);
                    // Check if data is returned
                    if (dtIngredient.Rows.Count > 0)
                    {
                        // Bind data to UI elements
                        imgIngredient.ImageUrl = dtIngredient.Rows[0]["IngredientsImageURL"].ToString();
                        lblIngredientName.InnerText = dtIngredient.Rows[0]["IngredientsName"].ToString();
                        lblIngredientDescription.InnerText = dtIngredient.Rows[0]["IngredientsDescription"].ToString();
                        // Add more bindings as needed
                    }
                }
                else
                {
                    // Handle case where IngredientsID is not provided
                }
            }
        }
      

    }
}