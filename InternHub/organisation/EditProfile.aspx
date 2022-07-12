<%@ Page Title="Edit Profile" Language="C#" MasterPageFile="~/organisation/organisation.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="InternHub.organisation.EditProfile" %>
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

            <asp:Table runat="server" align="center" CssClass="table-responsive">

                <asp:TableRow>
                    <asp:TableCell CssClass="form-label">Name:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtOrgName" runat="server" style="margin-top: 20px;" CssClass="form-control" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ControlToValidate="txtOrgName" runat="server" ErrorMessage="Name is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" ControlToValidate="txtOrgName" runat="server" ErrorMessage="Enter a valid name!" ForeColor="Red" ValidationExpression="^[a-z A-Z]+$"></asp:RegularExpressionValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell CssClass="form-label">Major Stream:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtOrgStream" runat="server" style="margin-top: 20px;" CssClass="form-control" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorStream" ControlToValidate="txtOrgStream" runat="server" ErrorMessage="Stream is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell CssClass="form-label">Logo:</asp:TableCell>
                    <asp:TableCell>
                        <asp:Image ID="orgPhoto" runat="server" Height="180px" Width="180px" />
                        <asp:Panel ID="panelImage" runat="server" >
                            <asp:FileUpload ID="filePhoto" style="margin: 1vh 0 5px 0" runat="server" /> <br />
                            <asp:Button ID="btnPhotoUpload" runat="server" Text="Upload Image" UseSubmitBehavior="False" OnClick="btnPhotoUpload_Click" CausesValidation="False" />
                            <asp:Label ID="photoLabel" Text="PNG, JPG, JPEG files. Max 1 MB" runat="server" ForeColor="Blue"></asp:Label>
                            <asp:HiddenField ID="photoFileName" Visible="false" runat="server" />
                        </asp:Panel>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell class="form-label">Address:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtOrgAddress" TextMode="MultiLine" Width="400px" CssClass="form-control" style="resize:none; margin: 10px 6vh 0 0;" Height="85px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" ControlToValidate="txtOrgAddress" runat="server" ErrorMessage="Address is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell CssClass="form-label">Contact Number:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtOrgPhone" runat="server" MaxLength="10" TextMode="Phone" style="margin-top: 20px;" CssClass="form-control"  Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" ControlToValidate="txtOrgPhone" runat="server" ErrorMessage="Contact Number is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" ControlToValidate="txtOrgPhone" runat="server" ErrorMessage="Enter a valid Phone Number!" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell CssClass="form-label">Organisation Link:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtOrgLink" runat="server" TextMode="Url" CssClass="form-control" style="margin-top: 20px;" Width="400px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorLink" ControlToValidate="txtOrgLink" runat="server" ErrorMessage="URL is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorLink" ControlToValidate="txtOrgLink" runat="server" ErrorMessage="Enter a valid URL!" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell colspan="2" align="center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Update Profile" style="margin-bottom: 2vh;" CssClass="btn btn-danger" Font-Size="Large" OnClick="btnSubmit_Click" />
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </div>

    <script>
        var x = document.getElementsByTagName("table");
        x[0].style.borderCollapse = "separate";
        x[0].style.marginBottom = "5vh";
    </script>

</asp:Content>
