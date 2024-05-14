<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PerfurmeCity.UI.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css">

    <style>
        /* Define your custom styles here */
        .feature-icon {
            font-size: 3rem;
            color: #6c757d;
        }

        .feature-heading {
            font-size: 1.5rem;
            color: #333;
            margin-top: 20px;
        }

        .feature-description {
            color: #666;
            margin-top: 10px;
        }

        .cta-button {
            background-color: #6c757d;
            color: #fff;
            padding: 10px 20px;
            border-radius: 5px;
            text-transform: uppercase;
            font-weight: bold;
            transition: background-color 0.3s ease;
        }

            .cta-button:hover {
                background-color: #495057;
            }

        .image-container {
            position: relative;
            overflow: hidden;
            border-radius: 10px;
            margin-bottom: 20px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
        }

        .image-overlay {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.5);
            display: flex;
            align-items: center;
            justify-content: center;
            opacity: 0;
            transition: opacity 0.3s ease;
        }

        .image-container:hover .image-overlay {
            opacity: 1;
        }

        .image-text {
            color: #fff;
            font-size: 1.5rem;
            text-align: center;
            font-weight: bold;
            text-transform: uppercase;
            letter-spacing: 2px;
            transition: transform 0.3s ease;
        }

        .image-container:hover .image-text {
            transform: translateY(-20px);
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Welcome Section -->
    <!-- Welcome Section -->
    <div class="container text-center py-5">
        <h1 class="animate__animated animate__bounceInDown animate__delay-1s">Step into a World of Exquisite Fragrance</h1>
        <p class="lead">Elevate your senses with our exquisite collection of perfumes</p>
    </div>


    <!-- Features Section -->
    <div class="container my-5">
        <div class="row">
            <div class="col-md-4">
                <div class="animate__animated animate__fadeInUp animate__delay-1s">
                    <div class="image-container">
                        <img src="../IMAGES/ServerImage/bloe.JPG" alt="Feature 1 Image" class="img-fluid">
                        <div class="image-overlay">
                            <p class="image-text">Crafted with Passion</p>
                        </div>
                    </div>
                    <p class="feature-description">Each perfume is meticulously crafted with love and dedication, ensuring a sensory experience like no other.</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="animate__animated animate__fadeInUp animate__delay-2s">
                    <div class="image-container">
                        <img src="../IMAGES/ServerImage/burberry.JPG" alt="Feature 2 Image" class="img-fluid">
                        <div class="image-overlay">
                            <p class="image-text">Natural Ingredients</p>
                        </div>
                    </div>
                    <p class="feature-description">We use only the finest natural ingredients sourced from around the world, creating fragrances that are both luxurious and sustainable.</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="animate__animated animate__fadeInUp animate__delay-3s">
                    <div class="image-container">
                        <img src="../IMAGES/ServerImage/citizen jav.JPG" alt="Feature 3 Image" class="img-fluid">
                        <div class="image-overlay">
                            <p class="image-text">Timeless Elegance</p>
                        </div>
                    </div>
                    <p class="feature-description">Our perfumes embody timeless elegance and sophistication, allowing you to make a lasting impression wherever you go.</p>
                </div>
            </div>
        </div>
    </div>

    <!-- Recommended Products Section -->
    <div class="container my-5">
        <h2 class="text-center mb-4">Recommended Products</h2>
        <div class="row">
            <div class="col-md-4">
                <div class="animate__animated animate__fadeInUp animate__delay-1s">
                    <div class="image-container">
                        <img src="../IMAGES/ServerImage/Cologne mankind.JPG" alt="Product 1 Image" class="img-fluid">
                        <div class="image-overlay">
                            <p class="image-text">Product Name</p>
                        </div>
                    </div>
                    <p class="feature-description">Product Description</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="animate__animated animate__fadeInUp animate__delay-2s">
                    <div class="image-container">
                        <img src="../IMAGES/ServerImage/azzaro.JPG" alt="Product 2 Image" class="img-fluid">
                        <div class="image-overlay">
                            <p class="image-text">AZZARO</p>
                        </div>
                    </div>
                    <p class="feature-description">Product Description</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="animate__animated animate__fadeInUp animate__delay-3s">
                    <div class="image-container">
                        <img src="../IMAGES/ServerImage/fahrenh.JPG" alt="Product 3 Image" class="img-fluid">
                        <div class="image-overlay">
                            <p class="image-text">Product Name</p>
                        </div>
                    </div>
                    <p class="feature-description">Product Description</p>
                </div>
            </div>
        </div>
    </div>

    <!-- Recommended Ingredients Section -->
    <div class="container my-5">
        <h2 class="text-center mb-4">Recommended Ingredients</h2>
        <div class="row">
            <div class="col-md-4">
                <div class="animate__animated animate__fadeInUp animate__delay-1s">
                    <div class="image-container">
                        <img src="../IMAGES/ServerImage/amber.jpg" alt="Ingredient 1 Image" class="img-fluid">
                        <div class="image-overlay">
                            <p class="image-text">AMBER</p>
                        </div>
                    </div>
                    <p class="feature-description">Ingredient Description</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="animate__animated animate__fadeInUp animate__delay-2s">
                    <div class="image-container">
                        <img src="../IMAGES/ServerImage/ambrette-seed.jpg" alt="Ingredient 2 Image" class="img-fluid">
                        <div class="image-overlay">
                            <p class="image-text">Amber seeds</p>
                        </div>
                    </div>
                    <p class="feature-description">Ingredient Description</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="animate__animated animate__fadeInUp animate__delay-3s">
                    <div class="image-container">
                        <img src="../IMAGES/ServerImage/benzoin.jpg" alt="Ingredient 3 Image" class="img-fluid">
                        <div class="image-overlay">
                            <p class="image-text">Ingredient Name</p>
                        </div>
                    </div>
                    <p class="feature-description">Ingredient Description</p>
                </div>
            </div>
        </div>
        <%-- sectiopn2 --%>
        <div class="row">
            <div class="col-md-4">
                <div class="animate__animated animate__fadeInUp animate__delay-1s">
                    <div class="image-container">
                        <img src="../IMAGES/ServerImage/benzoin.jpg" alt="Ingredient 1 Image" class="img-fluid">
                        <div class="image-overlay">
                            <p class="image-text">BENZOIN</p>
                        </div>
                    </div>
                    <p class="feature-description">Ingredient Description</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="animate__animated animate__fadeInUp animate__delay-2s">
                    <div class="image-container">
                        <img src="../IMAGES/ServerImage/black-pepper.jpg" alt="Ingredient 2 Image" class="img-fluid">
                        <div class="image-overlay">
                            <p class="image-text">BLACK PAPPER</p>
                        </div>
                    </div>
                    <p class="feature-description">Ingredient Description</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="animate__animated animate__fadeInUp animate__delay-3s">
                    <div class="image-container">
                        <img src="../IMAGES/ServerImage/benzoin.jpg" alt="Ingredient 3 Image" class="img-fluid">
                        <div class="image-overlay">
                            <p class="image-text">Ingredient Name</p>
                        </div>
                    </div>
                    <p class="feature-description">Ingredient Description</p>
                </div>
            </div>
        </div>
    </div>

    <!-- Call to Action Section -->
    <div class="container text-center my-5">
        <h2>Experience the Magic of Perfume City Today</h2>
        <p class="lead">Discover your signature scent and embark on a journey of luxury and refinement</p>
        <a href="#" class="cta-button">Explore Now</a>
    </div>
</asp:Content>
