<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="ProductsByGender.aspx.cs" Inherits="PerfurmeCity.UI.ProductsByGender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <asp:Repeater ID="rptIngredients" runat="server">
                <ItemTemplate>
                    <div class="col-md-3 mb-4">
                        <div class="card">
                            <asp:Image runat="server" class="card-img-top" ImageUrl='<%# Eval("IngredientsImageURL") %>' alt='<%# Eval("IngredientsName") %>' />
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("IngredientsName") %></h5>
                                <p class="card-text">Description: <%# Eval("IngredientsDescription") %></p>
                                <a runat="server" href='<%# "IngridentDetails.aspx?IngredientsID=" + Eval("IngredientsID") %>' class="btn btn-primary">Details</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
