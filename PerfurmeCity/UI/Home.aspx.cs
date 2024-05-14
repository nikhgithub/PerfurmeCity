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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Call method to fetch ingredients and bind them to UI
                BindProducts();
            }

        }
        protected void BindProducts()
        {
            // Create a DataTable to hold products
            DataTable dtProducts = new DataTable();
            ProductDAL productDAL = new ProductDAL();
            // Fetch products from database
            dtProducts = productDAL.GetProductsFromDatabase();

            // Check if any products were retrieved
            if (dtProducts.Rows.Count > 0)
            {
                // Initialize the HTML string to hold all the card HTML
                string cardsHtml = "<div class='row'>";

                // Counter to keep track of the number of cards in the current row
                int cardCount = 0;

                // Loop through products and generate HTML dynamically for each product
                foreach (DataRow row in dtProducts.Rows)
                {
                    string productName = row["ProductName"].ToString();
                    string description = row["Description"].ToString();
                    string tags = row["Tags"].ToString();
                    decimal price = Convert.ToDecimal(row["Price"]);
                    decimal discount = Convert.ToDecimal(row["Discount"]);
                    string gender = row["Gender"].ToString();
                    string imageUrl = row["ImageUrl"].ToString();

                    // Generate HTML for each product card
                    string cardHtml = $@"
    <div class='col-md-3'>
        <div class='card product-card'>
            <img class='card-img-top' src='https://media.istockphoto.com/id/1328673585/photo/bottles-of-essential-oil-with-rosemary-thyme-cinnamon-sticks-cardamom-mint-lavender-rose.jpg?s=1024x1024&w=is&k=20&c=77I3tx9Au2F_fQ4v50jH5Yqwv4VCujMeW5CKWr0dhyI=' alt='{productName}'>
            <div class='card-body'>
                <h5 class='card-title'>{productName}</h5>
                <p class='card-text'>{description}</p>
                <p class='card-text'>Price: ${price}</p>
                <p class='card-text'>Tags: {tags}</p>
                <p class='card-text'>Gender: {gender}</p>
                {(discount > 0 ? $"<p class='card-text'>Discount: {discount}%</p>" : "")}
                <button class='btn btn-primary'>Add to Cart</button>
            </div>
        </div>
    </div>";

                    // Append the card HTML to the overall cards HTML
                    cardsHtml += cardHtml;

                    // Increment card count
                    cardCount++;

                    // If four cards have been added, close the current row and start a new row
                    if (cardCount == 4)
                    {
                        cardsHtml += "</div><div class='row'>";
                        cardCount = 0;
                    }
                }

                // Close the last row if it's not already closed
                if (cardCount > 0)
                {
                    cardsHtml += "</div>";
                }

                // Set the generated HTML to the cardContainer div
                //cardContainer.InnerHtml = cardsHtml;
            }
            else
            {
                // If no products found, display a message
                //cardContainer.InnerHtml = "<p>No products found.</p>";
            }
        }



    }
}