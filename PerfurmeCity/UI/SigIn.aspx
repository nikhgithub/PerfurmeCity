<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="SigIn.aspx.cs" Inherits="PerfurmeCity.UI.SigIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <script>
      document.addEventListener("DOMContentLoaded", function () {
          document.getElementById("lnkRegisterNow").addEventListener("click", function () {
              document.getElementById("registrationForm").style.display = "block";
              document.getElementById("loginForm").style.display = "none";
          });

          document.getElementById("lnkLoginNow").addEventListener("click", function () {
              document.getElementById("registrationForm").style.display = "none";
              document.getElementById("loginForm").style.display = "block";
          });
      });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center mt-5">
            <div class="col-md-6">
                <!-- Registration Form -->
                <div id="registrationForm" class="card bg-dark text-white">
                    <div class="card-body">
                        <h2 class="text-center mb-4">Registration</h2>
                        <asp:Label ID="lblRegistrationError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control mb-3" placeholder="Name" Style="background-color: #333; color: white; border-color: #333;"></asp:TextBox>
                        <asp:TextBox ID="txtAge" runat="server" CssClass="form-control mb-3" placeholder="Age" Style="background-color: #333; color: white; border-color: #333;"></asp:TextBox>
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control mb-3" Style="background-color: #333; color: white; border-color: #333;">
                            <asp:ListItem Text="Select Gender" Value="" />
                            <asp:ListItem Text="Male" Value="Male" />
                            <asp:ListItem Text="Female" Value="Female" />
                            <asp:ListItem Text="Other" Value="Other" />
                        </asp:DropDownList>
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control mb-3" placeholder="Mobile" Style="background-color: #333; color: white; border-color: #333;"></asp:TextBox>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-3" placeholder="Email" Style="background-color: #333; color: white; border-color: #333;"></asp:TextBox>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control mb-3" placeholder="Password" Style="background-color: #333; color: white; border-color: #333;"></asp:TextBox>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control mb-3" placeholder="Confirm Password" Style="background-color: #333; color: white; border-color: #333;"></asp:TextBox>
                        <asp:Button ID="btnRegister" runat="server" Text="Register"  OnClick="btnRegister_Click" CssClass="btn btn-primary btn-block" Style="background-color: #007bff; border-color: #007bff;" />
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <!-- Login Form -->
                <div id="loginForm" class="card bg-dark text-white">
                    <div class="card-body">
                        <h2 class="text-center mb-4">Login Here</h2>
                        <asp:Label ID="lblLoginError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                        <asp:TextBox ID="txtLoginEmailOrMobile" runat="server" CssClass="form-control mb-3" placeholder="Email or Mobile Number" AutoPostBack="true" Style="background-color: #333; color: white; border-color: #333;"></asp:TextBox>
                        <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password" CssClass="form-control mb-3" placeholder="Password" Style="background-color: #333; color: white; border-color: #333;"></asp:TextBox>
                        <asp:Button ID="btnSignIn" runat="server" Text="Sign In" CssClass="btn btn-primary btn-block" Style="background-color: #007bff; border-color: #007bff;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
