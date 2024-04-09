<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PerfurmeCity.UI.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Slider Section -->
    <div id="perfumeCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ul class="carousel-indicators">
            <li data-target="#perfumeCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#perfumeCarousel" data-slide-to="1"></li>
            <li data-target="#perfumeCarousel" data-slide-to="2"></li>
        </ul>

        <!-- The slideshow -->
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="../IMAGES/test3.jpg" alt="Perfume Slide 1" class="d-block w-100">
            </div>
            <div class="carousel-item">
                <img src="../IMAGES/test3.jpg" alt="Perfume Slide 2" class="d-block w-100">
            </div>
            <div class="carousel-item">
                <img src="../IMAGES/test3.jpg" alt="Perfume Slide 3" class="d-block w-100">
            </div>
        </div>

        <!-- Left and right controls -->
        <a class="carousel-control-prev" href="#perfumeCarousel" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#perfumeCarousel" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>

    <!-- Featured Perfumes Section -->
    <div class="container mt-5">
        <h2 class="text-center">Featured Perfumes</h2>
        <div class="row">
            <!-- Example Card for a Perfume -->
            <div class="col-md-4">
                <div class="card">
                    <img class="card-img-top" src="../IMAGES/6.jfif" alt="Perfume Name">
                    <div class="card-body">
                        <h5 class="card-title">Perfume Name</h5>
                        <p class="card-text">Brief description of the perfume. Highlight what makes it special.</p>
                        <a href="#" class="btn btn-primary">Discover</a>
                    </div>
                </div>
            </div>

            <!-- Add more cards for other perfumes as needed -->
            <!-- Example Card for a Perfume -->
            <div class="col-md-4">
                <div class="card">
                    <img class="card-img-top" src="../IMAGES/6.jfif" alt="Perfume Name">
                    <div class="card-body">
                        <h5 class="card-title">Perfume Name</h5>
                        <p class="card-text">Brief description of the perfume. Highlight what makes it special.</p>
                        <a href="#" class="btn btn-primary">Discover</a>
                    </div>
                </div>
            </div>
            <!-- Example Card for a Perfume -->
            <div class="col-md-4">
                <div class="card">
                    <img class="card-img-top" src="../IMAGES/6.jfif" alt="Perfume Name">
                    <div class="card-body">
                        <h5 class="card-title">Perfume Name</h5>
                        <p class="card-text">Brief description of the perfume. Highlight what makes it special.</p>
                        <a href="#" class="btn btn-primary">Discover</a>
                    </div>
                </div>
            </div>
        </div>
        <h2 class="text-center">Best Sellers</h2>
        <div class="row">
            <!-- Example Card for a Perfume -->
            <div class="col-md-4">
                <div class="card">
                    <img class="card-img-top" src="../IMAGES/6.jfif" alt="Perfume Name">
                    <div class="card-body">
                        <h5 class="card-title">Perfume Name</h5>
                        <p class="card-text">Brief description of the perfume. Highlight what makes it special.</p>
                        <a href="#" class="btn btn-primary">Discover</a>
                    </div>
                </div>
            </div>

            <!-- Add more cards for other perfumes as needed -->
            <!-- Example Card for a Perfume -->
            <div class="col-md-4">
                <div class="card">
                    <img class="card-img-top" src="../IMAGES/6.jfif" alt="Perfume Name">
                    <div class="card-body">
                        <h5 class="card-title">Perfume Name</h5>
                        <p class="card-text">Brief description of the perfume. Highlight what makes it special.</p>
                        <a href="#" class="btn btn-primary">Discover</a>
                    </div>
                </div>
            </div>
            <!-- Example Card for a Perfume -->
            <div class="col-md-4">
                <div class="card">
                    <img class="card-img-top" src="../IMAGES/6.jfif" alt="Perfume Name">
                    <div class="card-body">
                        <h5 class="card-title">Perfume Name</h5>
                        <p class="card-text">Brief description of the perfume. Highlight what makes it special.</p>
                        <a href="#" class="btn btn-primary">Discover</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Why Choose Us Section -->
    <div class="container mt-5">
        <h2 class="text-center">Why Choose Our Perfumes?</h2>
        <div class="row">
            <div class="col-md-4">
                <h4>Quality Ingredients</h4>
                <p>Our perfumes are made from the finest natural ingredients, sourced from around the world.</p>
            </div>
            <div class="col-md-4">
                <h4>Exquisite Fragrances</h4>
                <p>Each perfume is a masterpiece, crafted with expertise to offer a unique and captivating scent.</p>
            </div>
            <div class="col-md-4">
                <h4>Lasting Impressions</h4>
                <p>Designed for longevity, our perfumes ensure you leave a lasting impression wherever you go.</p>
            </div>
        </div>
    </div>
</asp:Content>
