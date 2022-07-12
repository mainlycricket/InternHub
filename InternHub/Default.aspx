<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InternHub._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
                <div id="carouselExampleCaptions" class="carousel slide carousel-fade" data-bs-ride="carousel">
 
                    <div class="carousel-inner">

                        <div class="carousel-item active">
                            <img src="InternHub%20Banner.png" class="d-block w-100" alt="InternHub Banner">
                        </div>

                        <div class="carousel-item">
                            <img src="InternHub%20Banner%202.jpg" class="d-block w-100" alt="Internship Banner">
                        </div>
                        
                        <div class="carousel-item">
                            <img src="InternHub%20Banner%203.png" class="d-block w-100" alt="Internship Benifits">
                        </div>

                    </div>

                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>

                        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>

                </div>


    <div style="margin: 2vh 1vh 0 0; font-size: 20px; font-weight: 400; line-height: 1.5; text-align: justify">
        
        <p>
            Welcome to InternHub! We provide a platform to connect internship seekers with internship providers.
            We aim to help the talented youth, particularly the freshers, to achieve some experience in their preferred industry.
            Aspiring interns and organisations can register themselves to make the most of this platform.
        </p>

        <p>
            While the organisations can publish internship openings across various streams, internship seekers can apply for them.
            Detailed info of organisations and applicants can be accessed by the opposite parties.
            Interns and organisations can access the detailed info of their respective internships by logging into their dashboards.
            Please check out the <a href="~/guidelines" runat="server">guidelines</a> section to understand the in-depth working of <i>InternHub</i>.
        </p>
        
    </div>


    

</asp:Content>
