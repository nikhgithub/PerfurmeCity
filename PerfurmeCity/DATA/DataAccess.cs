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
      
    }
}