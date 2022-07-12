<%@ Page Title="Edit Profile" Language="C#" MasterPageFile="~/intern/intern.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="InternHub.intern.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        table {
            border-collapse: unset;
            border: 2px solid blue;
            border-radius: 10px;
            background-color: #80f8bc99;
        }

        table tr td {
            padding: 5px;
        }

        .form-label {
            font-size: 18px;
            font-weight: bold;
            padding-left: 50px;
        }

    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2 style="text-align: center; margin: 3vh 0 3vh 0;">Edit Profile</h2>
            <table align="center" bgcolor="aqua">

                <tr>
                    <td class="form-label">Name:</td>
                    <td>
                        <asp:TextBox ID="txtInternName" runat="server" style="margin-top: 20px;" CssClass="form-control"  Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ControlToValidate="txtInternName" runat="server" ErrorMessage="Name is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" ControlToValidate="txtInternName" runat="server" ErrorMessage="Enter a valid name!" ForeColor="Red" ValidationExpression="^[a-z A-Z]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Photo:</td>
                    <td>
                        <asp:Image ID="internPhoto" runat="server" Height="180px" Width="180px" />
                        <asp:Panel ID="panelImage" runat="server">
                            <asp:FileUpload ID="filePhoto" style="margin: 1vh 0 5px 0" runat="server" /> <br />
                            <asp:Button ID="btnPhotoUpload" runat="server" Text="Upload Image" UseSubmitBehavior="False" OnClick="btnPhotoUpload_Click" CausesValidation="False" />
                            <asp:Label ID="photoLabel" Text="PNG, JPG, JPEG files. Max 1 MB" runat="server" ForeColor="Blue"></asp:Label>
                            <asp:HiddenField ID="photoFileName" Visible="false" runat="server" />
                        </asp:Panel>
                    </td>
                </tr>

                <tr>
                    <td class="form-label"><br />Address:</td>
                    <td>
                        <asp:TextBox ID="txtInternAddress" runat="server" TextMode="MultiLine" Width="400px" CssClass="form-control" style="resize:none; margin-top: 10px;" Height="85px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" ControlToValidate="txtInternAddress" runat="server" ErrorMessage="Address is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td class="form-label">Contact Number:</td>
                    <td>
                        <asp:TextBox ID="txtInternPhone" runat="server" MaxLength="10" style="margin-top: 20px;" TextMode="Phone" CssClass="form-control" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" ControlToValidate="txtInternPhone" runat="server" ErrorMessage="Contact Number is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" ControlToValidate="txtInternPhone" runat="server" ErrorMessage="Enter a valid Phone Number!" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Intern Title:</td>
                    <td>
                        <asp:TextBox ID="txtInternTitle" runat="server" CssClass="form-control" style="margin-top: 20px;" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" ControlToValidate="txtInternTitle" runat="server" ErrorMessage="Title is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Portfolio:</td>
                    <td>
                        <asp:TextBox ID="txtInternPortfolio" runat="server" TextMode="Url"  style="margin-top: 20px;" CssClass="form-control" Width="400px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPortfolio" ControlToValidate="txtInternPortfolio" runat="server" ErrorMessage="URL is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorPortfolio" ControlToValidate="txtInternPortfolio" runat="server" ErrorMessage="Enter a valid URL!" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Skills:</td>
                    <td>
                        <asp:TextBox ID="txtInternSkills" runat="server" style="resize:none; margin: 10px 6vh 0 0;" TextMode="MultiLine" CssClass="form-control" Height="85px" Width="400px"></asp:TextBox>
                        <asp:Label ID="lblSkills" runat="server" Text="Separate skills by a comma." ForeColor="Blue"></asp:Label> <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSkills" ControlToValidate="txtInternSkills" runat="server" ForeColor="Red" ErrorMessage="Enter a skill!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td class="form-label">Qualifications:</td>
                    <td>
                        <asp:TextBox ID="txtInternQualifications" runat="server" style="resize:none; margin-top: 20px;" CssClass="form-control" Height="85px" Width="400px" ></asp:TextBox>
                        <asp:Label ID="lblQualifications" runat="server" Text="Separate qualifications by a comma." ForeColor="Blue" CssClass="auto-style2" Height="16px" Width="266px"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorQualifications" ControlToValidate="txtInternQualifications" ForeColor="Red" runat="server" ErrorMessage="Enter a qualification!"></asp:RequiredFieldValidator> <br />
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Resume:</td>
                    <td>
                        <asp:HyperLink ID="internResume" Target="_blank" ForeColor="Red" runat="server">View Resume</asp:HyperLink>
                        <asp:Panel ID="panelResume" runat="server">
                            <asp:FileUpload ID="fileResume" runat="server" /><br />
                            <asp:Button ID="btnResumeUpload" runat="server" Text="Upload" UseSubmitBehavior="False" OnClick="btnResumeUpload_Click" CausesValidation="False" />
                            <asp:Label ID="resumeLabel" runat="server" ForeColor="Blue" Text="PDF files. Max 2 MB"></asp:Label>
                            <asp:HiddenField ID="resumeFileName" Visible="false" runat="server" />
                        </asp:Panel>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Update Profile" style="margin: 2vh 0 2vh 0" Font-Bold="False" Font-Size="Large" OnClick="btnSubmit_Click" CssClass="btn btn-danger" />
                    </td>
                </tr>

            </table>

        </div>

    <script>
        var x = document.getElementsByTagName("table");
        x[0].style.borderCollapse = "separate";
        x[0].style.marginBottom = "5vh";
    </script>

</asp:Content>
