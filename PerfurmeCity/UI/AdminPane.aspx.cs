using PerfurmeCity.DATA;
using PerfurmeCity.MODELS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PerfurmeCity.UI
{
    public partial class AdminPane : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }
        protected void btnSaveProduct_Click(object sender, EventArgs e)
        {

            int value = ddlGenderFilter.SelectedIndex;

            Ingridients newproduct = new Ingridients();
            newproduct.IngridientsName = txtProductName.Text;
            newproduct.IngridientsDescription = txtDescription.Text;
            newproduct.IngridientsImageURL = Path.GetFileName(fileUploadProductImage.FileName);
            newproduct.IngridientsGender = ddlGenderFilter.SelectedItem.Value;
            newproduct.IngridientsPrice = Convert.ToInt32(txtPrice.Text);
            newproduct.IngridientsDiscount = Convert.ToDecimal(txtOffer.Text);
            newproduct.Ingridientstags = txttags.Text;
            SaveProductInformation(newproduct);



        }
        protected void SaveProductInformation(Ingridients ingridients)
        {
            // Check if a file was uploaded
            if (fileUploadProductImage.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(ingridients.IngridientsImageURL);
                    string folderPath = Server.MapPath("~/IMAGES/ServerImage/");

                    // Ensure the directory exists
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fullPath = folderPath + filename;

                    // Save the file to the specified folder
                    fileUploadProductImage.SaveAs(fullPath);

                    Ingridients ingridient = new Ingridients
                    {
                        IngridientsName = ingridients.IngridientsName,
                        IngridientsDescription = ingridients.IngridientsDescription,
                        IngridientsImageURL = "~/IMAGES/ServerImage/" + filename,
                        Ingridientstags = ingridients.Ingridientstags,
                        IngridientsDiscount = Convert.ToDecimal(ingridients.IngridientsDiscount),
                        IngridientsPrice = Convert.ToDecimal(ingridients.IngridientsPrice)
                    };
                    DataAccess dao = new DataAccess();
                    // Save product information in the database
                    dao.SaveIngredient(ingridient);
                    btnSaveProduct.Text = "Save";
                }
                catch (Exception ex)
                {
                    lblNotification.Text = "Error: " + ex.Message;
                    lblNotification.ForeColor = Color.Red;
                    lblNotification.Visible = true;
                    return;
                }

                lblNotification.Text = "Record saved successfully";
                lblNotification.ForeColor = Color.Green;
                lblNotification.Visible = true;
            }
            else
            {
                lblNotification.Text = "Please select a file to upload.";
                lblNotification.ForeColor = Color.Red;
                lblNotification.Visible = true;
            }
        }

    }
}