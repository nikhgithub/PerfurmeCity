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

            Products newproduct = new Products();
            newproduct.productName = txtProductName.Text;
            newproduct.prodcutDescription = txtDescription.Text;
            newproduct.productImageURL = fileUploadProductImage.FileName;
            newproduct.ProductGender = ddlGenderFilter.SelectedItem.Value;
            newproduct.ProductPrice = Convert.ToInt32(txtPrice.Text);
            newproduct.ProductDiscount = Convert.ToDecimal(txtOffer.Text);
            newproduct.Producttags = txttags.Text;
            SaveProductInformation(newproduct);



        }
        protected void SaveProductInformation(Products product)
        {
            // Check if a file was uploaded
            if (fileUploadProductImage.HasFile)
            {
                try
                {
                    string fileName = Path.GetFileName(product.productImageURL);
                    string folderPath = Server.MapPath("~/IMAGES/Ingredients/");

                    // Ensure the directory exists
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Generate a unique name for the file to avoid name conflicts
                    string uniqueFileName = fileName;
                    string fullPath = folderPath + uniqueFileName;

                    // Save the file to the specified folder
                    fileUploadProductImage.SaveAs(fullPath);

                    // Create a new product instance and set properties
                    Products newProduct = new Products
                    {
                        productName = txtProductName.Text,
                        prodcutDescription = txtDescription.Text,
                        productImageURL = "~/IMAGES/Ingredients/" + uniqueFileName, // Save the relative path
                        ProductGender = ddlGenderFilter.SelectedItem.Value,
                        ProductPrice = Convert.ToInt32(txtPrice.Text),
                        ProductDiscount = Convert.ToDecimal(txtOffer.Text),
                        Producttags = txttags.Text
                    };

                    // Save product information in the database
                    SaveProductInformation(newProduct);
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