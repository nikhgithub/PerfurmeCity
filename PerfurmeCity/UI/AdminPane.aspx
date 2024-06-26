﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="AdminPane.aspx.cs" Inherits="PerfurmeCity.UI.AdminPane" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <asp:Button ID="btnExportToExcel" CssClass="btn btn-success" runat="server" OnClick="btnExportToCSV_Click" Text="Export to Excel" />
    </div>

    <div class="container mt-5">
        <center>
            <h2>Add New Ingredients</h2>
        </center>
        <!-- Form for adding/editing products -->
        <asp:Panel ID="panelAddEditProduct" runat="server" DefaultButton="btnSaveProduct">
            <asp:HiddenField ID="hfProductID" runat="server" Value="0" />
            <div class="form-group">
                <label for="txtProductName">Enter Ingredient Name:</label>
                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDescription">Description:</label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDescription">Search Tags#:</label>
                <asp:TextBox ID="txttags" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDescription">How To Use(Label Print)</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblGenderFilter" runat="server" AssociatedControlID="ddlGenderFilter" Text="Filter by Gender:"></asp:Label>
                <asp:DropDownList ID="ddlGenderFilter" runat="server" CssClass="form-control">
                    <asp:ListItem Value="" Text="All" />
                    <asp:ListItem Value="Male" Text="Male" />
                    <asp:ListItem Value="Female" Text="Female" />
                    <asp:ListItem Value="Unisex" Text="Unisex" />
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" AssociatedControlID="ddlproductFilter" Text="Filter by Products:"></asp:Label>
                <asp:DropDownList ID="ddlproductFilter" runat="server" CssClass="form-control">
                    <asp:ListItem Value="All" Text="ProductType" />
                    <asp:ListItem Value="Ingrident" Text="Ingrident" />
                    <asp:ListItem Value="Products" Text="Products" />
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="fileUploadProductImage">Product Image:</label>
                <asp:FileUpload ID="fileUploadProductImage" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtPrice">Price:</label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtOffer">Offer:</label>
                <asp:TextBox ID="txtOffer" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblNotification" runat="server" CssClass="form-control" Text="record nessage" Visible="false"></asp:Label>
            </div>

            <asp:Button ID="btnSaveProduct" CssClass="btn btn-primary" runat="server" OnClick="btnSaveProduct_Click" Text="Save Product" />

        </asp:Panel>


    </div>
</asp:Content>
