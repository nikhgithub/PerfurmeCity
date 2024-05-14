using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PerfurmeCity.DATA;
using PerfurmeCity.MODELS;

namespace PerfurmeCity.UI
{
    public partial class OurIngridents : System.Web.UI.Page
    {
        string userId = ""; // Default value
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Call a method to fetch ingredients from the database
                PopulateIngredients();
               
                if (Session["UserID"] != null)
                {
                    userId = Session["UserID"].ToString();
                }
            }
        }
        protected void PopulateIngredients()
        {
            DataAccess dataAccessobj = new DataAccess();
            DataTable dataTable = dataAccessobj.GetAllIngredients();

            rptIngredients.DataSource = dataTable;
            rptIngredients.DataBind();


        }


        protected void AddToCart_Click(object sender, EventArgs e)
        {
            // Get the user ID (replace "GetUserID" with your method to retrieve the user ID)

            if (Session["UserID"] != null)
            {
                userId = Session["UserID"].ToString();
            }

            // Get the ingredient ID from the CommandArgument of the button
            int ingredientId = int.Parse(((Button)sender).CommandArgument);

            // Retrieve the ingredient details from the database or wherever you store them
            DataAccess dataAccessing = new DataAccess();
            Ingridients ingredient = dataAccessing.GetIngredientById(ingredientId);

            // Create a new cart item
            CartItems cartItem = new CartItems
            {
                IngredientID = ingredient.IngridientsID,
                IngredientName = ingredient.IngridientsName,
                Price = ingredient.IngridientsPrice,
                Quantity = 1, // Assuming you're adding one unit by default
                UserID = userId // Set the user ID
            };

            // Retrieve existing cart items from session or initialize a new list
            List<CartItems> cartItems = Session["CartItems"] as List<CartItems> ?? new List<CartItems>();

            // Add the new cart item to the list
            cartItems.Add(cartItem);
            DataAccess cartDAL = new DataAccess();
            cartDAL.AddToCart(userId, cartItem.IngredientID, cartItem.Quantity);
            // Update the session variable with the updated cart items list
            Session["CartItems"] = cartItems;
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Item added to cart!');", true);
        }


    }


}