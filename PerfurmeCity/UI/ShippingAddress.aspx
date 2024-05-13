<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="ShippingAddress.aspx.cs" Inherits="PerfurmeCity.UI.ShippingAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="text-dark">Shipping Address</h2>
        <div class="row">
            <!-- Shipping Address Section -->
            <div class="col-md-6">
                <h3 class="text-light">Shipping Address</h3>
                <div class="form-group">
                    <label for="txtName" class="text-light">Name</label>
                    <input type="text" id="txtName" class="form-control" placeholder="Enter your name" />
                </div>
                <div class="form-group">
                    <label for="txtemailNumber" class="text-light">Email</label>
                    <input type="text" id="txtemailNumber" class="form-control" placeholder="Enter your Email" />
                </div>
                <div class="form-group">
                    <label for="txtPhoneNumber" class="text-light">Phone Number</label>
                    <input type="text" id="txtPhoneNumber" class="form-control" placeholder="Enter your phone number" />
                </div>
                <div class="form-group">
                    <label for="txtAddress" class="text-light">Address</label>
                    <input type="text" id="txtAddress" class="form-control" placeholder="Enter your address" />
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="txtCity" class="text-light">City</label>
                        <input type="text" id="txtCity" class="form-control" placeholder="Enter your city" />
                    </div>
                    <div class="form-group col-md-3">
                        <label for="ddlState" class="text-light">State</label>
                        <select id="ddlState" class="form-control">
                            <option value="">Select State</option>
                            <option value="AL">Alabama</option>
                            <option value="AK">Alaska</option>
                            <option value="AZ">Arizona</option>
                            <option value="AR">Arkansas</option>
                            <option value="CA">California</option>
                            <option value="CO">Colorado</option>
                            <option value="CT">Connecticut</option>
                            <option value="DE">Delaware</option>
                            <option value="DC">District of Columbia</option>
                            <option value="FL">Florida</option>
                            <option value="GA">Georgia</option>
                            <option value="HI">Hawaii</option>
                            <option value="ID">Idaho</option>
                            <option value="IL">Illinois</option>
                            <option value="IN">Indiana</option>
                            <option value="IA">Iowa</option>
                            <option value="KS">Kansas</option>
                            <option value="KY">Kentucky</option>
                            <option value="LA">Louisiana</option>
                            <option value="ME">Maine</option>
                            <option value="MD">Maryland</option>
                            <option value="MA">Massachusetts</option>
                            <option value="MI">Michigan</option>
                            <option value="MN">Minnesota</option>
                            <option value="MS">Mississippi</option>
                            <option value="MO">Missouri</option>
                            <option value="MT">Montana</option>
                            <option value="NE">Nebraska</option>
                            <option value="NV">Nevada</option>
                            <option value="NH">New Hampshire</option>
                            <option value="NJ">New Jersey</option>
                            <option value="NM">New Mexico</option>
                            <option value="NY">New York</option>
                            <option value="NC">North Carolina</option>
                            <option value="ND">North Dakota</option>
                            <option value="OH">Ohio</option>
                            <option value="OK">Oklahoma</option>
                            <option value="OR">Oregon</option>
                            <option value="PA">Pennsylvania</option>
                            <option value="RI">Rhode Island</option>
                            <option value="SC">South Carolina</option>
                            <option value="SD">South Dakota</option>
                            <option value="TN">Tennessee</option>
                            <option value="TX">Texas</option>
                            <option value="UT">Utah</option>
                            <option value="VT">Vermont</option>
                            <option value="VA">Virginia</option>
                            <option value="WA">Washington</option>
                            <option value="WV">West Virginia</option>
                            <option value="WI">Wisconsin</option>
                            <option value="WY">Wyoming</option>
                        </select>
                        </select>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="txtZip" class="text-light">Zip Code</label>
                        <input type="text" id="txtZip" class="form-control" placeholder="Enter your zip code" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="ddlDeliveryMode" class="text-light">Delivery Mode</label>
                    <select id="ddlDeliveryMode" class="form-control">
                        <option value="">Select Delivery Mode</option>
                        <option value="Standard">Standard</option>
                        <option value="Express">Express</option>
                        <!-- Add more delivery modes as needed -->
                    </select>
                </div>
            </div>

            <!-- Billing Details Section -->
            <div class="col-md-6">
                <h3 class="text-dark">Billing Details</h3>
                <!-- Add dynamic content for billing details here -->
                <div class="form-group">
                    <label for="txtTotalPrice" class="text-dark">Total Price</label>
                    <input type="text" id="txtTotalPrice" class="form-control" readonly="true" placeholder="Enter total price" />
                </div>
                <!-- You can add more billing details fields here if needed -->
            </div>
        </div>

        <!-- Place Order Button -->
        <div class="row mt-3">
            <div class="col-md-12">
                
                <asp:Button runat="server" OnClick="Unnamed_Click" CssClas="btn btn-primary btn-block" Text="Save & Place Order" />
            </div>
        </div>
    </div>
</asp:Content>
