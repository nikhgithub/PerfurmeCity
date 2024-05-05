<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="PerfurmeCity.UI.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .cart-container {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
        }

        .cart-item {
            width: calc(25% - 20px); /* Adjust width to fit 4 items per row with gap */
            background-color: #f8f9fa; /* Light background color */
            border: 1px solid #dee2e6; /* Gray border */
            padding: 20px;
        }

        .item-details {
            display: flex;
        }

        .item-image {
            width: 100px; /* Adjust image width */
            height: 100px; /* Adjust image height */
            margin-right: 20px; /* Add space between image and info */
        }

        .item-info h3 {
            margin-top: 0; /* Remove default margin */
        }

        .buy-now-container {
            width: 100%;
            text-align: center;
            margin-top: 20px; /* Add space between items and button */
        }

        .buy-now-button {
            padding: 10px 20px; /* Adjust button padding */
            font-size: 16px; /* Adjust font size */
            border-radius: 5px; /* Rounded corners */
            background-color: #007bff; /* Blue color */
            color: #fff; /* White text color */
            border: none; /* Remove border */
        }

            .buy-now-button:hover {
                background-color: #0056b3; /* Darker blue on hover */
                cursor: pointer; /* Change cursor on hover */
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Cart Items</h2>
        <asp:Repeater ID="rptCartItems" runat="server">
            <ItemTemplate>
                <div class="cart-item">
                    <asp:Image ID="imgItem" runat="server" Width="100" Height="100" />
                    <h3><%# Eval("IngredientName") %></h3>
                    <!-- Add other item details here -->
                    <asp:CheckBox ID="chkSelect" runat="server" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Button ID="btnBuyNow" runat="server" Text="Buy Now" />
    </div>

</asp:Content>
