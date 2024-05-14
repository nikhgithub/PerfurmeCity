<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="OurIngridents.aspx.cs" Inherits="PerfurmeCity.UI.OurIngridents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css">
    <style>
        /* Container for the grid layout */
        .ingredient-grid {
            display: grid;
            grid-template-columns: repeat(auto-fill, minmax(400px, 1fr)); /* Responsive grid with minimum width of 400px */
            gap: 20px; /* Add space between grid items */
        }

        /* Individual ingredient box */
        .ingredient-box {
            display: flex; /* Use flexbox for horizontal layout */
            padding: 20px; /* Add padding for spacing */
            border: 1px solid #ccc; /* Add border around each box */
            border-radius: 10px; /* Add border radius for rounded corners */
            transition: transform 0.3s ease; /* Smooth transition on hover */
            box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1); /* Add shadow for depth */
            background-color: #fff; /* White background */
            overflow: hidden; /* Hide overflowing content */
            position: relative; /* Position relative for absolute positioning of content */
        }

        /* Image container */
        .image-container {
            width: 200px; /* Fixed width for image container */
            height: 200px; /* Fixed height for image container */
            overflow: hidden; /* Prevent image overflow */
            border-radius: 10px; /* Rounded corners */
        }

        /* Ingredient image */
        .ingredient-image {
            width: 100%; /* Set image width to 100% */
            height: 100%; /* Set image height to 100% */
            object-fit: cover; /* Maintain aspect ratio and cover container */
        }

        /* Box content */
        .box-content {
            flex: 1; /* Take remaining space */
            padding-left: 20px; /* Add spacing between image and content */
        }

        /* Add to cart button */
        .add-to-cart-button {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 8px 12px;
            cursor: pointer;
            border-radius: 4px;
            transition: background-color 0.3s ease; /* Smooth transition on hover */
            position: absolute; /* Position absolute for precise placement */
            bottom: 20px; /* 20px from the bottom */
            left: 20px; /* 20px from the left */
        }

        .add-to-cart-button:hover {
            background-color: #0056b3;
        }

        /* Notification */
        .notification {
            padding: 10px;
            background-color: #4CAF50; /* Green background */
            color: white; /* White text */
        }

        /* Animation on hover */
        .ingredient-box:hover {
            transform: translateY(-5px); /* Move up slightly on hover */
        }

        /* Additional animation classes */
        .slideInLeft {
            animation: slideInLeft 0.5s ease forwards;
        }

        @keyframes slideInLeft {
            0% {
                opacity: 0;
                transform: translateX(-100%);
            }
            100% {
                opacity: 1;
                transform: translateX(0);
            }
        }

        /* Description */
        .description {
            font-size: 14px;
            line-height: 1.5;
        }

        /* Title */
        .title {
            font-size: 18px;
            font-weight: bold;
            margin-bottom: 5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ingredient-grid">
        <asp:Repeater runat="server" ID="rptIngredients">
            <ItemTemplate>
                <div class="ingredient-box animate__animated animate__slideInLeft">
                    <div class="image-container">
                        <asp:Image ID="imgIngredient" runat="server" ImageUrl='<%# Eval("IngredientsImageURL") %>' AlternateText='<%# Eval("IngredientsName") %>' CssClass="ingredient-image" />
                    </div>
                    <div class="box-content">
                        <h3 class="title"><%# Eval("IngredientsName") %></h3>
                        <p class="description"><%# Eval("IngredientsDescription") %></p>
                    </div>
                    <asp:Button runat="server" ID="btnAddToCart" Text="Add to Cart" OnClick="AddToCart_Click" CommandArgument='<%# Eval("IngredientsID") %>' CssClass="add-to-cart-button" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
