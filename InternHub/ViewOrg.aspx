<%@ Page Title="Organisation Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewOrg.aspx.cs" Inherits="InternHub.ViewOrg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 id="head">Organisation Profile</h2>

    <div id="profile-container">

            <div id="profileHeader" style="display:flex">
                <div id="nameTitle">
                    <asp:Label ID="orgName" runat="server" Font-Size="30px" Font-Bold="True" Text=""></asp:Label> <br />
                    <asp:Label ID="orgStream" runat="server" Font-Size="24px" Font-Underline="True" Text=""></asp:Label>
                </div>
                <div id="image">
                    <asp:Image ID="orgLogo" runat="server" Height="150px" Width="150px" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" />
                </div>
            </div>

            <div id="orgProfileBody">
                <div>
                    <i class="fa fa-envelope" aria-hidden="true" style="font-size:24px; margin-top: 15px;"></i>&ensp;<asp:Hyperlink ID="org_email" runat="server" Font-Size="18px" Font-Italic="true"></asp:Hyperlink> 
                </div>

                <div>
                    <i class="fa fa-phone" style="font-size:24px"></i>&ensp;<asp:Hyperlink ID="org_phone" Font-Size="18px" runat="server" Text=""></asp:Hyperlink>
                </div>
                     
                <div id="DivOrgAddress">
                    <i class="fa-solid fa-address-card" style="font-size:24px;"></i>&ensp;<span style="font-size: 20px; font-weight: bold;">Address:</span><br />
                    <asp:Label ID="orgAddress" runat="server" Font-Size="18px"></asp:Label>
                </div>    
                    
                <div>
                    <asp:HyperLink ID="orgLink" runat="server" CssClass="btn btn-dark" Target="_blank">Organisation Website</asp:HyperLink> 
                </div>
                   
            </div>

        </div>
</asp:Content>
