<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="InternHub.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container-register">
           
             <table align="center">
                 <tr>
                     <td style="font-size: 18px;"><b>Role</b>&ensp;</td>
                    <td colspan="3">
                        <asp:DropDownList ID="userRoleSelect" CssClass="form-select" runat="server">
                            <asp:ListItem Text="Intern" Selected="True" Value="intern"></asp:ListItem>
                            <asp:ListItem Text="Organisation" Value="organisation"></asp:ListItem>
                        </asp:DropDownList>
                    </td>

                 </tr>

                 <tr>
                 <td colspan="2" style="text-align:center">
                     <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidatorRole" runat="server" ErrorMessage="Role is required" ControlToValidate="userRoleSelect" EnableClientScript="False" ></asp:RequiredFieldValidator>
                 </td>
                 </tr>
             </table>
                
             <div class="control">
                    <asp:TextBox ID="userEmail" runat="server" placeholder="Email" TextMode="Email" CssClass="form-control"></asp:TextBox> <br/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Email is required" ControlToValidate="userEmail" ForeColor="Red" EnableClientScript="False"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Enter a valid email!" ControlToValidate="userEmail" ForeColor="Red" EnableClientScript="False" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
           
                <div class="control" style="margin: -20px 0 -20px 0">
               
                    <asp:TextBox ID="userPassword" runat="server" placeholder="Password" TextMode="Password" CssClass="form-control"></asp:TextBox> <br/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Password is required" ControlToValidate="userPassword" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            
                <div class="control">
                    <asp:TextBox ID="confirmPassword" runat="server" placeholder="Retype Password" TextMode="Password" CssClass="form-control"></asp:TextBox> <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCnfPassword" runat="server" ControlToValidate="confirmPassword" ErrorMessage="Retype password" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidatorCnfPassword" runat="server" ErrorMessage="Both passwords should match!" ControlToValidate="confirmPassword" ControlToCompare="userPassword" Operator="Equal" Type="String" ForeColor="Red" EnableClientScript="False"></asp:CompareValidator>
                </div>
        <div align="center" style="margin-top: -20px;">
            <asp:Button ID="btnRegistser" runat="server" Text="Register" Font-Bold="True" OnClick="btnRegistser_Click" CssClass="form-control" BackColor="#6949F5" ForeColor="White" />
            <br />
            <asp:Label ID="formResposnse" runat="server" Text=""></asp:Label>
            </div>
        </div>
</asp:Content>
