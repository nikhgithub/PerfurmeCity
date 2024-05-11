<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="PerfurmeCity.UI.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .cart-container {
            display: flex;
            flex-wrap: wrap;
            justify-content: space-around;
            padding: 20px;
            background-color: #1a1a1a;
            color: #fff;
        }

        .cart-item {
            width: 200px;
            padding: 10px;
            margin: 10px;
            background-color: #333;
            border-radius: 10px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.3);
        }

            .cart-item img {
                width: 100%;
                border-radius: 5px;
            }

            .cart-item h3 {
                font-size: 16px;
                margin: 10px 0;
            }

            .cart-item .controls {
                display: flex;
                justify-content: space-between;
                align-items: center;
            }

            .cart-item .delete-symbol {
                font-size: 18px;
                color: #ff4d4d;
                cursor: pointer;
            }

                .cart-item .delete-symbol:hover {
                    color: #e60000;
                }

        #btnBuyNow {
            margin-top: auto; /* Aligns button to bottom of container */
            padding: 10px 20px;
            background-color: #4CAF50;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

            #btnBuyNow:hover {
                background-color: #45a049;
            }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">

    <script>
        function deleteCartItem(cartDetailID) {
            if (confirm("Are you sure you want to delete this item from your cart?" + cartDetailID)) {
                // Call backend function to delete cart item using AJAX
                // Example using jQuery AJAX
                $.ajax({
                    type: "POST",
                    url: "DeleteCartItem.aspx",
                    data: { cartDetailID: cartDetailID },
                    success: function (response) {
                        // Refresh the cart items after deletion
                        // Example: Reload the page
                        location.reload();
                    },
                    error: function (xhr, status, error) {
                        console.error(error);
                        alert("Failed to delete cart item.");
                    }
                });
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <center>
            <h2>Cart Items</h2>
        </center>
    </div>
    <div class="cart-container">
        <asp:Repeater ID="rptCartItems" runat="server">
            <ItemTemplate>
                <div class="cart-item">
                    <asp:Image ID="imgItem" runat="server" Width="150" Height="150" ImageUrl='<%# Eval("IngredientsImageURL") %>' />
                    <h3><%# Eval("IngredientName") %></h3>
                    <div class="controls">
                        <asp:CheckBox ID="chkSelect" runat="server" CssClass="checkbox-label" />
                        <span class="delete-symbol" onclick="deleteCartItem(<%# Eval("CartDetailID") %>);">&#10006;</span>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
    <div>
        <asp:Button ID="btnBuyNow" runat="server" Text="Buy Now" CssClass="btn btn-primary" />
    </div>
</asp:Content>
