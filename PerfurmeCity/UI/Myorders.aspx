<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Myorders.aspx.cs" Inherits="PerfurmeCity.UI.Myorders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css">
    <style>
        /* Card styling */
        .order-card {
            position: relative;
            overflow: hidden;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease;
            margin-bottom: 20px;
        }

        .order-card:hover {
            transform: translateY(-5px);
        }

        /* Order details styling */
        .order-details {
            padding: 20px;
        }

        .order-id {
            font-size: 18px;
            font-weight: bold;
            margin-bottom: 10px;
        }

        .ingredient-name {
            font-size: 16px;
            margin-bottom: 5px;
        }

        .order-info {
            margin-bottom: 10px;
        }

        /* Animation */
        .animate__fadeInUp {
            animation: fadeInUp 0.5s ease;
        }

        @keyframes fadeInUp {
            0% {
                opacity: 0;
                transform: translateY(20px);
            }
            100% {
                opacity: 1;
                transform: translateY(0);
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="animate__animated animate__fadeInUp">My Orders</h2>
        <asp:Repeater ID="rptOrders" runat="server">
            <ItemTemplate>
                <div class="order-card animate__animated animate__fadeInUp">
                    <div class="order-details">
                        <div class="order-id">Order ID: <%# Eval("OrderID") %></div>
                        <div class="ingredient-name">Ingredient: <%# Eval("IngredientsName") %></div>
                        <div class="order-info">
                            Quantity: <%# Eval("Quantity") %><br />
                            Price Per Item: $<%# Eval("Price") %><br />
                            Total Price: $<%# Eval("TotalPrice") %><br />
                            Order Date: <%# Eval("OrderDate", "{0:dd/MM/yyyy}") %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
