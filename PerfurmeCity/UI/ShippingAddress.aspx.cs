using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PerfurmeCity.UI
{
    public partial class ShippingAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            // Sender's email address and password (replace with your own)
            //string senderEmail = "anupa.gopiraj@gmail.com";
            //string senderPassword = "abcd@9BBB";

            //// Sender's email address and password (replace with your own)

            //// Recipient's email address
            //string recipientEmail = "arjunnandha8@gmail.com";

            //// Create a MailMessage object
            //MailMessage mailMessage = new MailMessage();
            //mailMessage.From = new MailAddress(senderEmail);
            //mailMessage.To.Add(new MailAddress(recipientEmail));
            //mailMessage.Subject = "Test Email";
            //mailMessage.Body = "This is a test email.";

            //// Create a SmtpClient object
            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.Host = "smtp.gmail.com"; // For Gmail
            //smtpClient.Port = 587; // Port for Gmail
            //smtpClient.EnableSsl = true;
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            //try
            //{
            //    // Send the email
            //    smtpClient.Send(mailMessage);
            //    Console.WriteLine("Email Sent Successfully.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error: " + ex.Message);
            //}


        }
        // Method to generate the HTML email body
        private string GenerateEmailBody(string orderDetails)
        {
            // Here you can use your creativity to design the HTML email body
            string body = @"
                <html>
                <head>
                    <style>
                        /* Add your CSS styles here */
                    </style>
                </head>
                <body>
                    <h2>Order Confirmation</h2>
                    <p>Thank you for your order!</p>
                    <p>Order Details:</p>
                    <p>" + orderDetails + @"</p>
                </body>
                </html>";

            return body;
        }
    }
}