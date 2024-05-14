<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="ShippingAddress.aspx.cs" Inherits="PerfurmeCity.UI.ShippingAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
    function showOrderIDPopup(orderID) {
        alert("Your Order ID is: " + orderID);
    }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="text-dark">Shipping Address</h2>
        <div class="container">
            <div class="row">
                <!-- Shipping Address Section -->
                <div class="col-md-6">
                    <h3 class="text-light">Shipping Address</h3>
                    <div class="form-group">
                        <asp:Label ID="lblName" runat="server" CssClass="text-light" AssociatedControlID="txtName">Name</asp:Label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter your name"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblEmail" runat="server" CssClass="text-light" AssociatedControlID="txtemailNumber">Email</asp:Label>
                        <asp:TextBox ID="txtemailNumber" runat="server" CssClass="form-control" placeholder="Enter your Email"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblPhoneNumber" runat="server" CssClass="text-light" AssociatedControlID="txtPhoneNumber">Phone Number</asp:Label>
                        <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" placeholder="Enter your phone number"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblAddress1" runat="server" CssClass="text-light" AssociatedControlID="txtAddress1">Address 1</asp:Label>
                        <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control" placeholder="Enter your address"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblAddress2" runat="server" CssClass="text-light" AssociatedControlID="txtAddress2">Address 2</asp:Label>
                        <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control" placeholder="Enter your address"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <asp:Label ID="lblCity" runat="server" CssClass="text-light" AssociatedControlID="txtCity">City</asp:Label>
                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="Enter your city"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3">
                            <asp:Label ID="lblState" runat="server" CssClass="text-light" AssociatedControlID="ddlState">State</asp:Label>
                            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Select State</asp:ListItem>
                                <asp:ListItem Value="AL">Alabama</asp:ListItem>
                                <asp:ListItem Value="AK">Alaska</asp:ListItem>
                                <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                                <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                                <asp:ListItem Value="CA">California</asp:ListItem>
                                <asp:ListItem Value="CO">Colorado</asp:ListItem>
                                <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                                <asp:ListItem Value="DE">Delaware</asp:ListItem>
                                <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                                <asp:ListItem Value="FL">Florida</asp:ListItem>
                                <asp:ListItem Value="GA">Georgia</asp:ListItem>
                                <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                                <asp:ListItem Value="ID">Idaho</asp:ListItem>
                                <asp:ListItem Value="IL">Illinois</asp:ListItem>
                                <asp:ListItem Value="IN">Indiana</asp:ListItem>
                                <asp:ListItem Value="IA">Iowa</asp:ListItem>
                                <asp:ListItem Value="KS">Kansas</asp:ListItem>
                                <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                                <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                                <asp:ListItem Value="ME">Maine</asp:ListItem>
                                <asp:ListItem Value="MD">Maryland</asp:ListItem>
                                <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                                <asp:ListItem Value="MI">Michigan</asp:ListItem>
                                <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                                <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                                <asp:ListItem Value="MO">Missouri</asp:ListItem>
                                <asp:ListItem Value="MT">Montana</asp:ListItem>
                                <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                                <asp:ListItem Value="NV">Nevada</asp:ListItem>
                                <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                                <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                                <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                                <asp:ListItem Value="NY">New York</asp:ListItem>
                                <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                                <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                                <asp:ListItem Value="OH">Ohio</asp:ListItem>
                                <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                                <asp:ListItem Value="OR">Oregon</asp:ListItem>
                                <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                                <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                                <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                                <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                                <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                                <asp:ListItem Value="TX">Texas</asp:ListItem>
                                <asp:ListItem Value="UT">Utah</asp:ListItem>
                                <asp:ListItem Value="VT">Vermont</asp:ListItem>
                                <asp:ListItem Value="VA">Virginia</asp:ListItem>
                                <asp:ListItem Value="WA">Washington</asp:ListItem>
                                <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                                <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                                <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="form-group col-md-3">
                            <asp:Label ID="lblZip" runat="server" CssClass="text-light" AssociatedControlID="txtZip">Zip Code</asp:Label>
                            <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" placeholder="Enter your zip code"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblDeliveryMode" runat="server" CssClass="text-light" AssociatedControlID="ddlDeliveryMode">Delivery Mode</asp:Label>
                        <asp:DropDownList ID="ddlDeliveryMode" runat="server" CssClass="form-control">
                            <asp:ListItem Value="">Select Delivery Mode</asp:ListItem>
                            <asp:ListItem Value="BASIC">Basic Delivery</asp:ListItem>
                            <asp:ListItem Value="EX">Express Delivery</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <!-- Billing Details Section -->
                <div class="col-md-6">
                    <h3 class="text-dark">Billing Details</h3>
                    <!-- Add dynamic content for billing details here -->
                    <div class="form-group">
                        <asp:Label ID="lblTotalPrice" runat="server" CssClass="text-dark" AssociatedControlID="txtTotalPrice">Total Price</asp:Label>
                        <asp:TextBox ID="txtTotalPrice" runat="server" CssClass="form-control" ReadOnly="true" placeholder="Enter total price"></asp:TextBox>
                    </div>
                    <!-- You can add more billing details fields here if needed -->
                </div>
            </div>

            <!-- Place Order Button -->
            <div class="row mt-3">
                <div class="col-md-12">
                    <asp:Button runat="server" OnClick="Unnamed_Click" CssClass="btn btn-primary btn-block" Text="Save & Place Order" />
                </div>
            </div>
        </div>
</asp:Content>
