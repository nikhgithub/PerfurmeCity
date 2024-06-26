﻿using System;
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
                (IngredientsName, IngredientsDescription, IngredientsPrice, IngredientsTags, IngredientsDiscount, IngredientsGender, IngredientsImageURL, IngredientsCreatedDate, IngredientsIsActive,ProductType) 
                VALUES 
                (@Name, @Description, @Price, @Tags, @Discount, @Gender, @ImageURL, @CreatedDate, @IsActive,@ProductType)
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
                command.Parameters.AddWithValue("@ProductType", ingredient.ProductType);

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
                string query = "select * from Ingredients Where ProductType='Ingrident'";

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

        public DataTable ExecuteQueryForRecommendation(int firstCartId)
        {
            DataTable recommendedProducts = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT * FROM Ingredients ORDER BY IngredientsPrice;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstCartId", firstCartId);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(recommendedProducts);
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine("Error executing recommendation query: " + ex.Message);
                }
            }

            return recommendedProducts;
        }

        //get data by ingrident
        public DataTable GetIngredientDetailsByID(string ingredientsID)
        {
            DataTable dtIngredient = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // SQL query to select ingredient details based on ID
                    string query = "SELECT * FROM Ingredients WHERE IngredientsID = @IngredientsID";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IngredientsID", ingredientsID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    da.Fill(dtIngredient);
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    throw ex;
                }
            }

            return dtIngredient;
        }


        public DataTable GetIngredientsByGender(string IngredientsGender)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "";
                if (IngredientsGender== "unisex")
                {
                     query = "SELECT * FROM Ingredients WHERE ProductType='Products'";
                }
                else
                {
                     query = "SELECT * FROM Ingredients WHERE ProductType='Products' and IngredientsGender = @IngredientsGender";
                }
              
                
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredientsGender", IngredientsGender);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader); // Load data into DataTable
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine(ex.Message);
                }
            }

            return dt;
        }
        public DataTable GetAddressDetails(int userID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Address WHERE UserID = @UserID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                    else
                    {
                        // If address not found, return a DataTable with empty fields
                        dt.Columns.Add("AddressID", typeof(int));
                        dt.Columns.Add("Address1", typeof(string));
                        dt.Columns.Add("Address2", typeof(string));
                        dt.Columns.Add("Email", typeof(string));
                        dt.Columns.Add("Phone", typeof(string));
                        dt.Columns.Add("City", typeof(string));
                        dt.Columns.Add("ZipCode", typeof(string));
                        dt.Columns.Add("State", typeof(string));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine(ex.Message);
                }
            }

            return dt;
        }
        public decimal GetTotalPriceInCart(int userId)
        {
            decimal totalPrice = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT SUM(Ingredients.IngredientsPrice * CartDetails.Quantity) AS TotalPrice
                    FROM CartDetails
                    INNER JOIN Ingredients ON CartDetails.IngredientID = Ingredients.IngredientsID
                    WHERE CartDetails.UserID = @UserID
                ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId); // Add parameter to the query
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    totalPrice = Convert.ToDecimal(result);
                }
            }

            return totalPrice;
        }
        public string GenerateOrderID()
        {
            string orderID = "";

            // Generate a unique Order ID
            orderID = Guid.NewGuid().ToString("N").Substring(0, 8); // You can adjust the length of the Order ID as needed

            return orderID;
        }

        public void UpdateOrCreateAddress(int userID, string address1, string address2, string email, string phone, string city, string stringShippingMethod, string zipCode, string state)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"IF EXISTS (SELECT * FROM Address WHERE UserID = @UserID)
                                    UPDATE Address SET Address1 = @Address1, Address2 = @Address2, Email = @Email, Phone = @Phone, City = @City, ZipCode = @ZipCode, State = @State
                                    WHERE UserID = @UserID
                                ELSE
                                    INSERT INTO Address (UserID, Address1, Address2, Email, Phone, City,ShippingMethod, ZipCode, State)
                                    VALUES (@UserID, @Address1, @Address2, @Email, @Phone, @City,@ShippingMethod, @ZipCode, @State)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@Address1", address1 ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Address2", address2 ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Phone", phone ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@City", city ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ShippingMethod", stringShippingMethod);
                command.Parameters.AddWithValue("@ZipCode", zipCode ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@State", state ?? (object)DBNull.Value);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void CreateOrderDetails(int userID, DataTable orderDetails)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO OrderDetails (UserID, ProductID, Quantity, TotalPrice) VALUES (@UserID, @ProductID, @Quantity, @TotalPrice)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);

                try
                {
                    connection.Open();
                    foreach (DataRow row in orderDetails.Rows)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@ProductID", row["ProductID"]);
                        command.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                        command.Parameters.AddWithValue("@TotalPrice", row["TotalPrice"]);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public int GetUserIdBasedOnEmailAndPassword(string email, string password)
        {
            int userId = -1; // Default value if user not found

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID FROM Users WHERE Email = @Email AND Password = @Password";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    userId = Convert.ToInt32(result);
                }
            }

            return userId;
        }
        // Method to save order details from the shipping page
        public bool SaveOrderFromShippingPage(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Start a new transaction
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Get cart items for the user
                            DataTable cartItems = GetCartItemsForUser(userId, connection, transaction);

                            // Iterate through cart items and save order details
                            foreach (DataRow cartItem in cartItems.Rows)
                            {
                                int ingredientId = Convert.ToInt32(cartItem["IngredientID"]);
                                int quantity = Convert.ToInt32(cartItem["Quantity"]);

                                // Save order details for each cart item
                                SaveOrderDetails(userId, ingredientId, quantity, connection, transaction);
                            }
                            DeleteCartItems(userId, connection, transaction);

                            // Commit the transaction if all operations succeed
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction if an error occurs
                            transaction.Rollback();
                            // Log or handle the exception
                            throw ex;
                        }
                    }
                  
                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                    throw ex;
                }
            }
        }
        // Method to retrieve cart items for a user
        private DataTable GetCartItemsForUser(int userId, SqlConnection connection, SqlTransaction transaction)
        {
            DataTable cartItems = new DataTable();
            // Execute your SQL query to retrieve cart items for the user
            // Example:
            string query = "SELECT * FROM CartDetails WHERE UserID = @UserId";
            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@UserId", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(cartItems);
            return cartItems;
        }
        public DataTable GetAllOrderDetails()
        {
            DataTable dtOrders = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM UsersOrders";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtOrders);
                }
            }

            return dtOrders;
        }
        private void DeleteCartItems(int userId, SqlConnection connection, SqlTransaction transaction)
        {
            // Execute your SQL query to delete cart items for the user
            string query = "DELETE FROM CartDetails WHERE UserID = @UserId";
            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@UserId", userId);
            command.ExecuteNonQuery();
        }

        // Method to save order details for a cart item
        private void SaveOrderDetails(int userId, int ingredientId, int quantity, SqlConnection connection, SqlTransaction transaction)
        {
            // Execute your SQL query to save order details for the cart item
            // Example:
            string query = "INSERT INTO UsersOrders (UserID, IngredientID, IngredientName, Quantity, OrderDate) " +
                           "VALUES (@UserId, @IngredientId, @IngredientName, @Quantity, GETDATE())";
            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@UserId", userId);
            command.Parameters.AddWithValue("@IngredientId", ingredientId);
            command.Parameters.AddWithValue("@IngredientName", string.Empty); // Provide an empty string
            command.Parameters.AddWithValue("@Quantity", quantity);

            command.ExecuteNonQuery();
        }


        public DataTable GetAllProducts()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL query to select all products from Ingredients table where ProductType is "Products"
                    string query = "SELECT * FROM Ingredients WHERE ProductType = @ProductType";

                    // Create and open the connection
                    connection.Open();

                    // Create a command with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@ProductType", "Products");

                        // Create a data adapter to execute the command and fill the DataTable
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        dataAdapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log or throw them as needed
                Console.WriteLine("Error retrieving products: " + ex.Message);
            }

            return dataTable;
        }
        public DataTable GetMyOrders(int userId)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL query to get order details with calculated prices
                    string query = @"SELECT 
                                        O.OrderID,
                                        O.UserID,
                                        O.IngredientID,
                                        I.IngredientsName,
                                        O.Quantity,
                                        I.IngredientsPrice AS Price,
                                        O.Quantity * I.IngredientsPrice AS TotalPrice,
                                        O.ShippingAddressID,
                                        O.OrderDate
                                    FROM 
                                        UsersOrders O
                                    INNER JOIN 
                                        Ingredients I ON O.IngredientID = I.IngredientsID
                                    WHERE 
                                        O.UserID = @UserID";

                    // Create and open the connection
                    connection.Open();

                    // Create a command with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@UserID", userId);

                        // Create a data adapter to execute the command and fill the DataTable
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        dataAdapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log or throw them as needed
                Console.WriteLine("Error retrieving orders: " + ex.Message);
            }

            return dataTable;
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