<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGES/MasterLayout.Master" AutoEventWireup="true" CodeBehind="IngridentDetails.aspx.cs" Inherits="PerfurmeCity.UI.IngridentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Popup Styles */
        .popup {
            display: none;
            position: fixed;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background-color: rgba(0, 0, 0, 0.5);
            width: 100%;
            height: 100%;
        }

        .popup-content {
            position: relative;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            text-align: center;
        }

            .popup-content .close {
                position: absolute;
                top: 10px;
                right: 10px;
                cursor: pointer;
            }

            .popup-content p {
                font-size: 18px;
                color: #333;
                margin-bottom: 20px;
            }

        /* Contact Section Styles */
        .contact-section {
            margin-top: 50px;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            background-color: #f9f9f9;
        }

            .contact-section h2 {
                font-size: 24px;
                margin-bottom: 20px;
            }

            .contact-section p {
                font-size: 16px;
                color: #555;
                margin-bottom: 20px;
            }

        .address h3 {
            font-size: 18px;
            margin-bottom: 10px;
        }

        .address p {
            font-size: 16px;
            color: #777;
        }

        .contact-form h3 {
            font-size: 18px;
            margin-bottom: 10px;
        }

        .contact-form input[type="text"],
        .contact-form input[type="email"],
        .contact-form textarea {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .contact-form textarea {
            height: 100px;
        }

        .contact-form button {
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

            .contact-form button:hover {
                background-color: #0056b3;
            }

        /* Styling for <p> tags */
        p {
            font-family: 'Arial', sans-serif; /* Change the font family as desired */
            font-size: 16px; /* Adjust the font size */
            line-height: 1.6; /* Adjust the line height for better readability */
            color: #333; /* Set the text color */
            margin-bottom: 20px; /* Add spacing between paragraphs */
        }

            /* Example styling for paragraph with a drop cap */
            p.drop-cap {
                text-indent: 20px; /* Set the indentation for the first line */
                float: left; /* Float the paragraph to the left */
                margin-right: 15px; /* Add spacing between drop cap and text */
                font-size: 18px; /* Adjust the font size */
                line-height: 1.8; /* Adjust the line height */
            }

            /* Example styling for a highlighted paragraph */
            p.highlight {
                background-color: #f9f9f9; /* Set the background color */
                padding: 10px; /* Add padding for better visual appearance */
                border-left: 4px solid #ff9900; /* Add a left border for emphasis */
            }

        /* Container for ingredient details */
        .ingredient-details-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-top: 20px;
        }

        /* Ingredient image */
        .ingredient-image {
            width: 300px;
            height: auto;
            margin-bottom: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        /* Ingredient description */
        .ingredient-description {
            padding: 20px;
            background-color: #f9f9f9;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

        /* Static data section */
        .static-data {
            margin-top: 20px;
            text-align: center;
        }

        /* Footer section */
        .footer {
            margin-top: 50px;
            text-align: center;
        }

            /* Footer link */
            .footer a {
                color: #333;
                text-decoration: none;
            }

                /* Footer link hover */
                .footer a:hover {
                    text-decoration: underline;
                }
    </style>
    <script>
        // Get the contact form and popup elements
        var contactForm = document.getElementById('contactForm');
        var popup = document.getElementById('popup');
        var closeBtn = document.querySelector('.close');

        // Show popup message when form is submitted
        contactForm.addEventListener('submit', function (event) {
            event.preventDefault(); // Prevent form submission
            popup.style.display = 'block'; // Display the popup
        });

        // Close popup when close button is clicked
        closeBtn.addEventListener('click', function () {
            popup.style.display = 'none'; // Hide the popup
        });

        // Get the send button element
        var sendButton = document.getElementById("sendButton");

        // Add event listener for the send button click
        sendButton.addEventListener("click", function () {
            // Show an alert message
            alert("Our team will contact you soon!");
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Container for ingredient details -->
    <div class="ingredient-details-container">
        <!-- Ingredient image -->
        <asp:Image ID="imgIngredient" runat="server" CssClass="ingredient-image" />

        <!-- Ingredient description -->
        <div class="ingredient-description">
            <h2 id="lblIngredientName" runat="server"></h2>
            <p id="lblIngredientDescription" runat="server"></p>
        </div>

        <!-- Perfume Ingredients static information -->
        <div class="static-data">
            <h3>Perfume Ingredients</h3>
            <p class="drop-cap">In the heart of every fragrance lies a captivating tale, a symphony of scents that dances gracefully upon the senses, weaving an enchanting narrative that transcends time and space. Welcome to the realm of perfume ingredients, where each essence tells a story of its own, inviting you on an olfactory journey like no other.</p>
            <p class="highlight">Imagine strolling through a blooming garden, where the delicate petals of jasmine and rose whisper secrets of romance, while the citrusy notes of bergamot and mandarin add a refreshing zest to the air. Feel the warmth of amber and vanilla embrace you like a comforting embrace, as exotic spices tantalize your senses with their mysterious allure.</p>
            <p class="highlight">In this fragrant orchestra, every ingredient plays a unique role, harmonizing together to create a masterpiece that is as evocative as it is unforgettable. From the earthy richness of patchouli to the ethereal purity of white musk, each note contributes to the symphony, blending seamlessly to form a melody that resonates deep within the soul.</p>
            <p class="highlight">So close your eyes, inhale deeply, and let yourself be transported to a world of wonder and delight, where the essence of perfume ingredients invites you to embrace the beauty of scent in all its glorious forms.</p>
        </div>

    </div>

    <!-- Footer section -->
    <!-- Contact Us Section -->
    <div class="contact-section">
        <h2>Contact Us</h2>
        <p>If you have any questions or inquiries, feel free to reach out to us!</p>

        <!-- Dummy Address -->
        <div class="address">
            <h3>Our Location</h3>
            <p>123 Main Street, City, Country</p>
        </div>

        <!-- Contact Form (You can replace it with your actual contact form) -->
        <div class="contact-form">
            <h3>Send Us a Message</h3>
            <form id="contactForm" action="#" method="post">
                <input type="text" name="name" placeholder="Your Name" required>
                <input type="email" name="email" placeholder="Your Email" required>
                <textarea name="message" placeholder="Your Message" required></textarea>

            </form>
            <asp:Button runat="server" ID="sendButton" Text="Send" OnClick="sendButton_Click" />

        </div>

        <!-- Popup Message -->

    </div>
</asp:Content>
