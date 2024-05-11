using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using PerfurmeCity.MODELS;
using System.Reflection;
using System.Web.UI;
using System.Xml.Linq;

namespace PerfurmeCity.DATA
{
    public class DataAccess
    {
        // Get connection string from web.config
        private string connectionString = ConfigurationManager.ConnectionStrings["PerfurmDBConnectionString"].ConnectionString;

        // Method to save registration details to database using stored procedure

        public int SaveRegistrationDetails(Users newuser)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_SaveRegistrationDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                cmd.Parameters.AddWithValue("@Name", newuser.Name);
                cmd.Parameters.AddWithValue("@Age", newuser.Age);
                cmd.Parameters.AddWithValue("@Gender", newuser.gender);
                cmd.Parameters.AddWithValue("@Mobile", newuser.mobile);
                cmd.Parameters.AddWithValue("@Email", newuser.email);
                cmd.Parameters.AddWithValue("@Password", newuser.password);

                // Add output parameter to capture the return value from the stored procedure
                SqlParameter returnValue = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    // Get the return value from the stored procedure
                    int returnValueFromSP = Convert.ToInt32(returnValue.Value);
                    return returnValueFromSP;
                }
                catch (Exception ex)
                {
                    // Handle exceptions here
                    Console.WriteLine(ex.Message);
                    return -2; // Return custom error code
                }
                finally
                {
                    // Close the connection in the finally block to ensure it's always closed
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public int Login(string identifier, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                cmd.Parameters.AddWithValue("@Identifier", identifier);
                cmd.Parameters.AddWithValue("@Password", password);

                // Add output parameter to capture the return value from the stored procedure
                SqlParameter returnValue = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    // Get the return value from the stored procedure
                    int returnValueFromSP = Convert.ToInt32(returnValue.Value);
                    return returnValueFromSP;
                }
                catch (Exception ex)
                {
                    // Handle exceptions here
                    Console.WriteLine(ex.Message);
                    return -2; // Return custom error code
                }
                finally
                {
                    // Close the connection in the finally block to ensure it's always closed
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        //save ingredients
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


        //get all ingridents
        public DataTable GetAllIngredients()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select * from Ingredients";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                }
            }

            return dataTable;
        }

        public void AddIngredientToCart(string userId, string ingredientId)
        {
            // Implement the logic to add the ingredient to the user's cart
            // You'll need to insert the details into the CartDetails table
            // This method will depend on your database schema and how you handle user sessions
            // You may need to pass additional parameters like user ID, cart ID, etc.
        }
        public Ingridients GetIngredientById(int ingredientId)
        {
            Ingridients ingredient = null;

            string query = "SELECT * FROM Ingredients WHERE IngredientsID = @IngredientId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IngredientId", ingredientId); // Corrected parameter name

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        ingredient = new Ingridients
                        {
                            IngridientsID = Convert.ToInt32(reader["IngredientsID"]),
                            IngridientsName = reader["IngredientsName"].ToString(),
                            // Include other properties as needed
                        };
                    }

                    reader.Close();
                }
            }

            return ingredient;
        }
        public void AddToCart(string userId, int ingredientId, int quantity)
        {
            string query = "INSERT INTO CartDetails (UserID, IngredientID, Quantity, AddedDate) " +
                           "VALUES (@UserID, @IngredientID, @Quantity, @AddedDate)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@IngredientID", ingredientId);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@AddedDate", DateTime.Now);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<CartDetail> GetCartDetailsByUserID(int userID)
        {
            List<CartDetail> cartDetails = new List<CartDetail>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
    SELECT CD.CartDetailID, CD.UserID, CD.IngredientID, CD.Quantity, CD.AddedDate, 
           I.IngredientsID, I.IngredientsName, I.IngredientsPrice, I.IngredientsImageURL
    FROM CartDetails CD 
    INNER JOIN Ingredients I ON CD.IngredientID = I.IngredientsID 
    WHERE CD.UserID = @UserID";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CartDetail cartDetail = new CartDetail
                            {
                                CartDetailID = Convert.ToInt32(reader["CartDetailID"]),
                                UserID = reader["UserID"].ToString(),
                                IngredientID = Convert.ToInt32(reader["IngredientID"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                AddedDate = Convert.ToDateTime(reader["AddedDate"]),
                                IngredientName = reader["IngredientsName"].ToString(),
                                Price = Convert.ToDecimal(reader["IngredientsPrice"]),
                                IngredientsImageURL = Convert.ToString(reader["IngredientsImageURL"])
                                // Add other properties as needed
                            };
                            cartDetails.Add(cartDetail);
                        }
                    }
                }
            }

            return cartDetails;
        }
        public int DeleteCartDetail(int cartDetailID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM CartDetails WHERE CartDetailID = @CartDetailID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CartDetailID", cartDetailID);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }








    }
}
public class CartDetail
{
    public int CartDetailID { get; set; }
    public string UserID { get; set; }
    public int IngredientID { get; set; }
    public int Quantity { get; set; }
    public DateTime AddedDate { get; set; }
    public string IngredientName { get; set; }
    public decimal Price { get; set; }

    public string IngredientsImageURL { get; set; }
    // Add other properties as needed
}