<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="PerfurmeCity.UI.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css">
    <style>
        /* Card styling */
        .card {
            position: relative;
            overflow: hidden;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease;
        }

        .card:hover {
            transform: translateY(-5px);
        }

        /* Image styling */
        .card-img-top {
            width: 100%;
            height: 200px;
            object-fit: cover;
            transition: transform 0.3s ease;
        }

        /* Description styling */
        .card-body {
            padding: 20px;
        }

        .card-text {
            margin-bottom: 15px;
            font-size: 16px;
        }

        /* Details button styling */
        .details-button {
            position: absolute;
            bottom: 20px; /* Adjust the distance from the bottom */
            left: 50%; /* Center horizontally */
            transform: translateX(-50%); /* Center horizontally */
            z-index: 1;
        }

        .details-button a {
            display: inline-block;
            text-align: center;
            padding: 8px 16px;
            border-radius: 4px;
            background-color: #007bff;
            color: #fff;
            text-decoration: none;
            transition: background-color 0.3s ease;
        }

        .details-button a:hover {
            background-color: #0056b3;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <asp:Repeater ID="rptProducts" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="card animate__animated animate__fadeInUp">
                            <asp:Image runat="server" class="card-img-top" ImageUrl='<%# Eval("IngredientsImageURL") %>' alt='<%# Eval("IngredientsName") %>' />
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("IngredientsName") %></h5>
                                <p class="card-text"><%# Eval("IngredientsDescription") %></p>
                                <p class="card-text">Price: $<%# Eval("IngredientsPrice") %></p>
                            </div>
                            <div class="details-button">
                                <asp:HyperLink runat="server" NavigateUrl='<%# "IngridentDetails.aspx?IngredientsID=" + Eval("IngredientsID") %>' Text="Details"></asp:HyperLink>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

