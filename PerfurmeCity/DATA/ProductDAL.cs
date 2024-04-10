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
    }
}