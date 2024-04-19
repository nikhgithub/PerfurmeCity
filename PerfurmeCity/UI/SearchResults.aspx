<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="PerfurmeCity.UI.SearchResults" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>SEARCH RESULTS:
    </h3>
    <div id="cardContainer" runat="server" class="card-container">
        <!-- Cards will be dynamically added here -->
    </div>
</asp:Content>
