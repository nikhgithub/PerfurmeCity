using PerfurmeCity.MODELS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Diagnostics;

namespace PerfurmeCity.DATA
{
    public class ProductDAL
    {

        // Get connection string from web.config
        private string connectionString = ConfigurationManager.ConnectionStrings["PerfurmDBConnectionString"].ConnectionString;


        public DataTable searchResults(string searchparam)
        {
            DataTable dataTable = new DataTable();

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a SqlCommand object to execute the stored procedure
                using (SqlCommand command = new SqlCommand("SearchProducts", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the search parameter
                    command.Parameters.AddWithValue("@SearchParam", searchparam);

                    // Open the database connection
                    connection.Open();

                    // Create a SqlDataAdapter to fill the DataTable with the results
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Fill the DataTable with the results of the stored procedure
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;

        }

        public void SaveIngredient(Ingridients ingredient)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                INSERT INTO Ingredients 
                (IngredientsName, IngredientsDescription, IngredientsPrice, IngredientsTags, IngredientsDiscount, IngredientsGender, IngredientsImageURL, IngredientsCreatedDate, IngredientsIsActive) 
                VALUES 
                (@Name, @Description, @Price, @Tags, @Discount, @Gender, @ImageURL, @CreatedDate, @IsActive)
            ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", ingredient.IngridientsName);
                command.Parameters.AddWithValue("@Description", ingredient.IngridientsDescription);
                command.Parameters.AddWithValue("@Price", ingredient.IngridientsPrice);
                command.Parameters.AddWithValue("@Tags", ingredient.Ingridientstags ?? (object)DBNull.Value); // Handle null values
                command.Parameters.AddWithValue("@Discount", ingredient.IngridientsDiscount);
                command.Parameters.AddWithValue("@Gender", ingredient.IngridientsGender ?? (object)DBNull.Value); // Handle null values
                command.Parameters.AddWithValue("@ImageURL", ingredient.IngridientsImageURL ?? (object)DBNull.Value); // Handle null values
                command.Parameters.AddWithValue("@CreatedDate", DateTime.Now); // Use the current date and time
                command.Parameters.AddWithValue("@IsActive", ingredient.IngridientsIsActive);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                }
            }
        }


        public bool SaveProductInfo(Products newproduct)
        {
            bool isInserted = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_InsertProductV2", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@ProductName", SqlDbType.NVarChar, 255).Value = newproduct.productName;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar, -1).Value = newproduct.prodcutDescription;
                    command.Parameters.Add("@Tags", SqlDbType.NVarChar, 255).Value = newproduct.Producttags;
                    command.Parameters.Add("@Price", SqlDbType.Decimal).Value = newproduct.ProductPrice;
                    command.Parameters.Add("@Discount", SqlDbType.Decimal).Value = newproduct.ProductDiscount;
                    command.Parameters.Add("@Gender", SqlDbType.NVarChar, 50).Value = newproduct.ProductGender;
                    command.Parameters.Add("@ImageUrl", SqlDbType.NVarChar, -1).Value = newproduct.productImageURL;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                        // Handle exception
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return isInserted;
        }
        public DataTable GetProductsFromDatabase()
        {
            // Your database connection logic here
            DataTable dt = new DataTable();
            // Your SQL query to fetch products
            string query = "SELECT ProductName, Description, Tags, Price, Discount, Gender, ImageUrl FROM Products";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }
    }
}
