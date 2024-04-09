using PerfurmeCity.DATA;
using PerfurmeCity.MODELS;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            ProductDAL newproduct = new ProductDAL();
            bool isProductInserted = newproduct.SaveProductInfo(product);
            if (isProductInserted)
            {
                lblNotification.Text = "Record saved successfully";
                lblNotification.ForeColor = Color.Green;
                lblNotification.Visible = true;
            }
            else
            {
                lblNotification.Text = "Failed to save record";
                lblNotification.ForeColor = Color.Red;
                lblNotification.Visible = true;
            }
        }

    }
}