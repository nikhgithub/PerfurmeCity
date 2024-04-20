<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="PerfurmeCity.UI.SearchResults" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Custom CSS for the navbar */
        .filter-label {
            font-size: 0.9rem;
            color: #051a2d; /* Dark gray color */
        }

        .navbar-custom {
            background-color: #051a2d; /* Dark gray color */
        }

            .navbar-custom .nav-link {
                color: #ffffff; /* White color */
            }

            .navbar-custom .dropdown-menu {
                background-color: #051a2d; /* Dark gray color */
            }

            .navbar-custom .dropdown-item {
                color: #ffffff; /* White color */
            }

                .navbar-custom .dropdown-item:hover {
                    background-color: #495057; /* Light gray color on hover */
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Filter Navbar -->
    <nav class="navbar navbar-expand-md navbar-light bg-light navbar-custom mb-4">
        <span class="navbar-text filter-label">You can filter by:</span>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#filtersNavbar" aria-controls="filtersNavbar" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="filtersNavbar">
            <ul class="navbar-nav mr-auto">
                <!-- Price Filter Dropdown -->
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="priceFilterDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Price
                    </a>
                    <div class="dropdown-menu" aria-labelledby="priceFilterDropdown">
                        <!-- Price filter options can be dynamically populated here -->
                        <a class="dropdown-item" href="#" onclick="filterByPrice('0-50')">$0 - $50</a>
                        <a class="dropdown-item" href="#" onclick="filterByPrice('51-100')">$51 - $100</a>
                        <a class="dropdown-item" href="#" onclick="filterByPrice('101-200')">$100 - $200</a>
                        <a class="dropdown-item" href="#" onclick="filterByPrice('200>')">ABOVE $200</a>
                        <!-- Add more price range options as needed -->
                    </div>
                </li>
                <!-- Gender Filter Dropdown -->
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="genderFilterDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Gender
                    </a>
                    <div class="dropdown-menu" aria-labelledby="genderFilterDropdown">
                        <!-- Gender filter options -->
                        <a class="dropdown-item" href="#" onclick="filterByGender('Men')">Men</a>
                        <a class="dropdown-item" href="#" onclick="filterByGender('Women')">Women</a>
                        <a class="dropdown-item" href="#" onclick="filterByGender('Unisex')">Unisex</a>
                    </div>
                </li>
            </ul>
        </div>
    </nav>

    <!-- SEARCH RESULTS -->
    <h3>SEARCH RESULTS:</h3>
    <div id="cardContainer" runat="server" class="card-container">
        <!-- Cards will be dynamically added here -->
    </div>

    <!-- JavaScript to handle filtering -->
    <script>
        function filterByPrice(priceRange) {
            // Call server-side method to filter search results by price range
            $.ajax({
                type: "POST",
                url: "SearchResults.aspx/FilterByPrice", // Specify the URL of your server-side method
                data: JSON.stringify({ priceRange: priceRange }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Update cardContainer with filtered search results
                    $('#cardContainer').html(response.d);
                },
                failure: function (response) {
                    console.error("Filtering failed: " + response);
                }
            });
        }

        // Callback function for filter AJAX requests
        function onFilterSuccess(result) {
            // Update cardContainer with filtered search results
            $('#cardContainer').html(result);
        }

        function onFilterFailure(error) {
            console.error("Filtering failed: " + error);
        }
    </script>
</asp:Content>
