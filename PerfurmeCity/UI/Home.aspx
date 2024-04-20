<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PerfurmeCity.UI.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .product-card {
            width: 100%;
            height: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Slider Section -->
    <div id="perfumeCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ul class="carousel-indicators">
            <li data-target="#perfumeCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#perfumeCarousel" data-slide-to="1"></li>
            <li data-target="#perfumeCarousel" data-slide-to="2"></li>
            <li data-target="#perfumeCarousel" data-slide-to="3"></li>
            <li data-target="#perfumeCarousel" data-slide-to="4"></li>
            <li data-target="#perfumeCarousel" data-slide-to="5"></li>
        </ul>

        <!-- The slideshow -->
        <div class="carousel-inner">
            <div class="carousel-item active" style="max-width: 1000px;">
                <img src="../IMAGES/ValentynVolkov.jpg" alt="Perfume Slide 1" class="d-block w-100">
            </div>
            <div class="carousel-item">
                <img src="../IMAGES/IRA_EVVA.jpg" alt="Perfume Slide 2" class="d-block w-100">
            </div>
            <div class="carousel-item">
                <img src="../IMAGES/IRA_EVVA.jpg" alt="Perfume Slide 3" class="d-block w-100">
            </div>
            <div class="carousel-item active">
                <img src="../IMAGES/ValentynVolkov.jpg" alt="Perfume Slide 4" class="d-block w-100">
            </div>
            <div class="carousel-item">
                <img src="../IMAGES/ValentynVolkov.jpg" alt="Perfume Slide 5" class="d-block w-100">
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
    <center>
        <h3>Perfurme Ingridients:</h3>
    </center>
    <div id="cardContainer" runat="server" class="card-container">
        <!-- Cards will be dynamically added here -->
    </div>



    <!-- Why Choose Us Section -->
    <div class="container mt-5">
        <h2 class="text-center">Why Choose Our Perfumes?</h2>
        <div class="row">
            <div class="col-md-4">
                <h4>Quality Ingredients</h4>
                <p>Crafted with a meticulous selection of the finest natural essences sourced from around the globe, our perfumes epitomize luxury and sophistication. Each fragrance is a harmonious blend of carefully curated ingredients, meticulously extracted and combined to create captivating scents that evoke a sense of elegance and allure.</p>

                <p>From the lush floral notes of jasmine and rose to the exotic richness of sandalwood and patchouli, our perfumes offer a sensorial journey through nature's most exquisite offerings. Every ingredient is chosen for its purity, potency, and ability to harmonize with other elements, resulting in perfumes that not only smell divine but also linger delicately on the skin, leaving a lasting impression.</p>

                <p>At Perfume City, we believe that quality ingredients are the cornerstone of exceptional fragrances. That's why we spare no effort in sourcing the finest botanicals and extracts, ensuring that each perfume embodies the essence of luxury and refinement. Indulge your senses and experience the unparalleled craftsmanship of our perfumes, where every drop tells a story of unparalleled quality and sophistication."</p>
            </div>
            <div class="col-md-4">
                <h4>Exquisite Fragrances</h4>
                <p>"Step into a world of timeless elegance and sophistication with our collection of exquisite fragrances. Each scent is a meticulously crafted masterpiece, born from a fusion of artistry and olfactory expertise. From the first spritz to the lingering finish, our perfumes envelop you in an aura of luxury and refinement, leaving an indelible impression wherever you go.</p>

                <p>Drawing inspiration from the world's most enchanting landscapes and cultural treasures, our perfumers weave a tapestry of scents that captivate the senses and stir the soul. With each inhalation, you're transported to distant shores, enchanted forests, and sun-drenched gardens, where every scent tells a story of beauty and intrigue.</p>

                <p>Our commitment to excellence is evident in every facet of our fragrances, from the selection of premium ingredients to the meticulous blending process. Each note is carefully balanced to create a symphony of aromas that unfolds gracefully on the skin, revealing new nuances with every wear.</p>

                <p>Whether you're seeking a signature scent for everyday elegance or a statement fragrance for special occasions, our collection offers a diverse range of options to suit every style and mood. Discover the art of perfumery with our exquisite fragrances and elevate your olfactory journey to new heights of luxury and sophistication."</p>
            </div>
            <div class="col-md-4">
                <h4>Lasting Impressions</h4>
                <p>"Leave a lasting impression wherever you go with our collection of perfumes designed for longevity and allure. Crafted with precision and passion, each fragrance is a testament to the art of perfumery, offering an immersive experience that lingers on the skin and in the memory long after the initial application.</p>

                <p>Our perfumes are meticulously formulated to withstand the test of time, ensuring that you radiate elegance and sophistication from dawn till dusk. With a carefully curated blend of top, middle, and base notes, our fragrances unfold gradually, revealing new layers of complexity with each passing hour.</p>

                <p>Designed to complement your unique personality and style, our perfumes enhance your aura of confidence and allure, leaving a trail of intrigue in your wake. Whether you're attending a formal event, embarking on a romantic rendezvous, or simply going about your daily routine, our fragrances offer a touch of luxury and refinement that sets you apart from the crowd.</p>

                <p>Indulge in the pleasure of wearing a scent that resonates with your essence and leaves a lasting impression on everyone you encounter. Elevate your olfactory experience with our collection of perfumes, where every spray is a journey into elegance, sophistication, and timeless allure."</p>
            </div>
        </div>
    </div>
</asp:Content>
