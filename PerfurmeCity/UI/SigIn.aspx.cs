using PerfurmeCity.DATA;
using PerfurmeCity.MODELS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PerfurmeCity.UI
{
    public partial class SigIn : System.Web.UI.Page
    {
        int userID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Users newuser = new Users();
            newuser.Name = txtName.Text;
            newuser.Age = Convert.ToInt32(txtAge.Text);
            newuser.email = txtEmail.Text;
            newuser.password = txtPassword.Text;
            newuser.mobile = txtMobile.Text;
            newuser.gender = ddlGender.SelectedItem.ToString();
            GetRegistrationformdetails(newuser);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Login logic

            string text = btnSignIn.Text;

            int isAuthenticated = YourAuthenticationLogic(txtLoginEmailOrMobile.Text, txtLoginPassword.Text); // Implement your authentication logic here

            if (isAuthenticated == 1)
            {
                DataAccess dataAccess = new DataAccess();
                int userId = dataAccess.GetUserIdBasedOnEmailAndPassword(txtLoginEmailOrMobile.Text, txtLoginPassword.Text);

                // Store UserID in Session
                Session["UserID"] = userId;
                // Set session variable indicating user is logged in
                Session["IsLoggedIn"] = true;
                Response.Redirect("~/UI/Home.aspx"); // Redirect to dashboard or another page after login
            }
            else
            {

                // Display login failed message
                //lblLoginError.Text = "Invalid username or password.";
                string script = "alert('User not found.');";
                ClientScript.RegisterStartupScript(this.GetType(), "UserCreatedScript", script, true);
            }


        }
        protected int YourAuthenticationLogic(string username, string password)
        {
            DataAccess dal = new DataAccess();
            return dal.Login(username, password);


        }
        protected void GetRegistrationformdetails(Users objectuser)
        {
            DataAccess dal = new DataAccess();
            int retrunvalue = dal.SaveRegistrationDetails(objectuser);
            if (retrunvalue >= 1)
            {

                string script = "alert('User created successfully.');";
                ClientScript.RegisterStartupScript(this.GetType(), "UserCreatedScript", script, true);
                txtName.Text = "";
                txtAge.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtMobile.Text = "";
                ddlGender.SelectedIndex = 0;
            }
            else
            {
                string script = "alert('email or mobile already exists');";
                ClientScript.RegisterStartupScript(this.GetType(), "UserCreatedScript", script, true);

            }

        }
    }
}