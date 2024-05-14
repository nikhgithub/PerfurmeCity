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

            .cart-item .price {
                font-size: 14px;
                margin-bottom: 5px;
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
            margin-bottom: 20px; /* Add space below button */
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

        .recommendation-container {
            margin-top: 20px;
        }

        .recommended-products-wrapper {
            display: flex;
            overflow-x: auto;
            scroll-behavior: smooth;
            padding: 10px;
        }

        .recommended-product {
            flex: 0 0 auto;
            margin-right: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
            overflow: hidden;
        }

        .recommended-image {
            width: 100px; /* Adjust the width as needed */
            height: auto;
            display: block;
        }

        .arrow-wrapper {
            display: flex;
            justify-content: center;
            margin-top: 10px;
        }

        .arrow {
            background-color: #333;
            color: white;
            border: none;
            border-radius: 50%;
            padding: 10px 15px;
            margin: 0 5px;
            cursor: pointer;
        }

            .arrow:hover {
                background-color: #555;
            }

        .prev {
            transform: rotate(180deg);
        }

        .your-css-class-name {
            /* Your CSS styles here */
            /* For example: */
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
            border-radius: 5px;
        }
    </style>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">

    <script>
        function deleteCartItem(cartDetailID) {
            if (confirm("Are you sure you want to delete this item from your cart?")) {
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
        function scrollProducts(direction) {
            const container = document.querySelector('.recommended-products-wrapper');
            container.scrollBy({
                left: container.offsetWidth * direction,
                behavior: 'smooth'
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <center>
            <h2>CART DETIALS</h2>
        </center>
    </div>
    <div class="cart-container">
        <asp:Repeater ID="rptCartItems" runat="server">
            <ItemTemplate>
                <div class="cart-item">
                    <asp:Image ID="imgItem" runat="server" Width="150" Height="150" ImageUrl='<%# Eval("IngredientsImageURL") %>' />
                    <h3><%# Eval("IngredientName") %></h3>
                    <p class="price">Price: $<%# Eval("Price") %></p>
                    <div class="controls">
                        <span class="delete-symbol" onclick="deleteCartItem(<%# Eval("CartDetailID") %>);">&#10006;</span>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div>
        <asp:Button ID="btncartdetails" runat="server" CssClass="your-css-class-name" OnClick="btnBuyNow_Click" Text="PLACE ORDER" />

    </div>
    <asp:Repeater ID="rptRecommendedProducts" runat="server">
        <HeaderTemplate>
            <div class="recommendation-container">
                <h2>Similar Products</h2>
                <div class="recommended-products-wrapper">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="recommended-product">
                <asp:HyperLink ID="hlIngridentDetails" runat="server" NavigateUrl='<%# "IngridentDetails.aspx?IngredientsID=" + Eval("IngredientsID") %>'>
                    <asp:Image ID="imgRecommendedProduct" runat="server" ImageUrl='<%# Eval("IngredientsImageURL") %>' CssClass="recommended-image" AlternateText='<%# Eval("IngredientsName") %>' />
                </asp:HyperLink>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
    <!-- Close recommended-products-wrapper -->
            <div class="arrow-wrapper">
                <button class="arrow prev" onclick="scrollProducts(-1)">&#10094;</button>
                <button class="arrow next" onclick="scrollProducts(1)">&#10095;</button>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
