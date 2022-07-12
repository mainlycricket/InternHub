<%@ Page Title="Profile" Language="C#" MasterPageFile="~/intern/intern.Master" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="InternHub.intern.ViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 id="head">Intern Profile</h2>
    <div id="profile-container">
            <div id="profileHeader">
                <div id="nameTitle">
                    <asp:Label ID="internName" runat="server" Font-Size="30px" Font-Bold="True"></asp:Label> <br />
                    <asp:Label ID="internTitle" runat="server" Font-Size="24px" Font-Underline="True"></asp:Label>
                </div>
                <div id="image">
                    <asp:Image ID="internPhoto" runat="server" Height="150px" Width="150px" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" />
                </div>
            </div>

            <div id="profileBody" style="display:flex">

                <div id="educationalDetails">
                    <h3 style="text-decoration: underline">Skills:</h3>
                    <asp:Panel ID="internSkills" runat="server"></asp:Panel>
                    <h3 style="text-decoration: underline">Qualifications:</h3>
                    <asp:Panel ID="internQualifications" runat="server"></asp:Panel>
                </div>

                <div id="personalDetails">
                    <asp:HyperLink ID="internPortfolio" runat="server" Target="_blank" Font-Size="18px" Width="50%" CssClass="btnOwn">Portfolio</asp:HyperLink> <br />
                    <asp:HyperLink ID="internResume" runat="server" Target="_blank" CssClass="btnOwn" Font-Size="18px" Width="50%">Resume</asp:HyperLink> <br />
                    <div id="contactDetails">
                        <i class="fa fa-envelope" aria-hidden="true" style="font-size:24px"></i>&ensp;<asp:Hyperlink ID="intern_email" runat="server" Font-Size="18px" Font-Italic="true"></asp:Hyperlink>  <br />
                        <i class="fa fa-phone" style="font-size:24px"></i>&ensp;<asp:Hyperlink ID="intern_phone" Font-Size="18px" runat="server" Text=""></asp:Hyperlink> <br />
                        <i class="fa-solid fa-address-card" style="font-size:24px"></i>&ensp;<span style="font-size: 20px">Address:</span><br />
                        <asp:Label ID="internAddress" runat="server" Font-Size="18px"></asp:Label>
                    </div>
                    
                </div>

            </div>

        </div>
</asp:Content>
