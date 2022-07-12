<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InternHub.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-login">

        <div class="control">
            <asp:TextBox ID="userEmail" style="margin-top:15px;" placeholder="Email" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Email is required" ControlToValidate="userEmail" ForeColor="Red" EnableClientScript="False"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Enter a valid email!" ControlToValidate="userEmail" ForeColor="Red" EnableClientScript="False" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
        
        <div class="control">
            <asp:TextBox ID="userPassword" placeholder="Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="control">
            <asp:RequiredFieldValidator style="text-align: center" ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Password is required" ControlToValidate="userPassword" EnableClientScript="False" ForeColor="Red" Font-Overline="False"></asp:RequiredFieldValidator>
        </div>
        
        <div class="control">
            <asp:Button ID="btnLogin" CssClass="form-control" runat="server" Text="Login" Font-Bold="True" OnClick="btnLogin_Click" BackColor="#6949F5" ForeColor="White"/>
        </div>
            <asp:Label ID="formResposnse" runat="server" Text=""></asp:Label>
            <p id="registerLine" style="font-size:16px; margin-top:1.5vh; text-align: center;">New to InternHub?<br />
                <a href="Register.aspx" style="text-align: center; font-weight: bold;">Sign up!</a></p>
        
        
    </div>
</asp:Content>
