<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="OurIngridents.aspx.cs" Inherits="PerfurmeCity.UI.OurIngridents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        /* Container for the grid layout */
        .ingredient-grid {
            display: grid;
            grid-template-columns: repeat(4, 1fr); /* Each row contains 4 columns */
            gap: 20px; /* Add space between grid items */
        }

        /* Individual ingredient box */
        .ingredient-box {
            padding: 10px; /* Add padding for spacing */
            border: 1px solid #ccc; /* Add border around each box */
            border-radius: 5px; /* Add border radius for rounded corners */
        }

        /* Image container */
        .image-container {
            width: 100%; /* Set width to 100% */
            height: 150px; /* Fixed height for image */
            overflow: hidden; /* Prevent image overflow */
        }

        /* Ingredient image */
        .ingredient-image {
            width: 100%; /* Set image width to 100% */
            height: 100%; /* Set image height to 100% */
            object-fit: cover; /* Maintain aspect ratio and cover container */
        }

        /* Add to cart button */
        .add-to-cart-button {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 8px 12px;
            cursor: pointer;
            border-radius: 4px;
        }

            .add-to-cart-button:hover {
                background-color: #0056b3;
            }

        .notification {
            padding: 10px;
            background-color: #4CAF50; /* Green background */
            color: white; /* White text */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ingredient-grid">
        <asp:Repeater runat="server" ID="rptIngredients">
            <ItemTemplate>
                <div class="ingredient-box">
                    <div class="image-container">
                        <asp:Image ID="imgIngredient" runat="server" ImageUrl='<%# Eval("IngredientsImageURL") %>' AlternateText='<%# Eval("IngredientsName") %>' CssClass="ingredient-image" />
                    </div>
                    <h3><%# Eval("IngredientsName") %></h3>
                    <p><%# Eval("IngredientsDescription") %></p>
                    <p>Price: $<%# Eval("IngredientsPrice") %></p>
                    <asp:Button runat="server" ID="btnAddToCart" Text="Add to Cart" OnClick="AddToCart_Click" CommandArgument='<%# Eval("IngredientsID") %>' CssClass="add-to-cart-button" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>



</asp:Content>
