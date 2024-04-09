using PerfurmeCity.DATA;
using PerfurmeCity.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PerfurmeCity.UI
{
    public partial class SigIn : System.Web.UI.Page
    {
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
            newuser.gender = ddlGender.SelectedItem.ToString();
            GetRegistrationformdetails(newuser);
        }

        protected void GetRegistrationformdetails(Users objectuser)
        {
            DataAccess dal = new DataAccess();
            int retrunvalue = dal.SaveRegistrationDetails(objectuser);
        }
    }
}