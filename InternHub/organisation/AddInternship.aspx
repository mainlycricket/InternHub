<%@ Page Title="Add Internship" Language="C#" MasterPageFile="~/organisation/organisation.Master" AutoEventWireup="true" CodeBehind="AddInternship.aspx.cs" Inherits="InternHub.organisation.AddInternship" %>
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
        <h2 style="text-align: center; margin: 3vh 0 3vh 0;">Add Internship</h2>
            <table align="center">

                <tr>
                    <td class="form-label">Internship Title:</td>
                    <td>
                        <asp:TextBox ID="txtInternshipTitle" CssClass="form-control" style="margin-top: 20px;" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" ForeColor="Red" ControlToValidate="txtInternshipTitle" runat="server" ErrorMessage="Title is required!"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Stream:</td>
                    <td>
                        <asp:DropDownList ID="DropDownListStream" CssClass="form-select" style="margin-top: 20px;" Width="250px" runat="server" DataSourceID="SqlDataSourceStream" DataTextField="stream" DataValueField="stream" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorStream" ForeColor="Red" ControlToValidate="DropDownListStream" runat="server" ErrorMessage="A stream is required!"></asp:RequiredFieldValidator>
                        <asp:SqlDataSource ID="SqlDataSourceStream" runat="server" ConnectionString="<%$ ConnectionStrings:InternHubDB %>" SelectCommand="SELECT [stream] FROM [tblStreams]"></asp:SqlDataSource>
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Minimum Qualification:</td>
                    <td>
                        <asp:TextBox ID="txtInternshipQualification" CssClass="form-control" style="margin-top: 20px;" Width="400px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorQualification" ForeColor="Red" ControlToValidate="txtInternshipQualification" runat="server" ErrorMessage="Enter the required qualification!"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Required Skills:</td>
                    <td>
                        <asp:TextBox ID="txtInternshipRequirements" TextMode="MultiLine" Width="400px" CssClass="form-control" style="resize:none; margin-top: 10px;" Height="85px" runat="server"></asp:TextBox>
                        <asp:Label ID="lblRequiredSkills" runat="server" ForeColor="Blue" Text="Separate required skils by comma"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRequirements" ForeColor="Red" ControlToValidate="txtInternshipRequirements" runat="server" ErrorMessage="Skills are required!"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Responsibilities:</td>
                    <td>
                        <asp:TextBox ID="txtInternshipResponsibilites" TextMode="MultiLine" Width="400px" CssClass="form-control" style="resize:none; margin-top: 10px;" Height="85px" runat="server"></asp:TextBox>
                        <asp:Label ID="lblResponsibilties" runat="server" Text="Separate responsibilities skils by comma" ForeColor="Blue"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorResponsibilties" ControlToValidate="txtInternshipResponsibilites" runat="server" ErrorMessage="Responsibility is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Work from Home:</td>
                    <td>
                        <asp:CheckBox ID="CheckBoxWFH" runat="server" Text=" Yes" />
                    </td>
                </tr>

                <tr>
                    <td class="form-label">For Trainees:</td>
                    <td>
                        <asp:CheckBox ID="CheckBoxTrainee" runat="server" Text=" Yes" />
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Office Location:</td>
                    <td>
                        <asp:TextBox ID="txtInternshipLocation" TextMode="MultiLine" Width="400px" CssClass="form-control" style="resize:none; margin-top: 10px;" Height="85px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocation" ForeColor="Red" ControlToValidate="txtInternshipLocation" runat="server" ErrorMessage="Location is required!"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Duration (months):</td>
                    <td>
                        <asp:TextBox ID="txtInternshipDuration" TextMode="Number" CssClass="form-control" style="margin-top: 20px;" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDuration" ForeColor="Red" ControlToValidate="txtInternshipDuration" runat="server" ErrorMessage="Duration is required!"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidatorDuration" ControlToValidate="txtInternshipDuration" Type="Integer" ValueToCompare="0" Operator="GreaterThan" runat="server" ErrorMessage="Invalid duration" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Closing Date:</td>
                    <td>
                        <asp:TextBox ID="internshipClosingDate" TextMode="Date" CssClass="form-control" style="margin-top: 20px;" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorClosingDate" ForeColor="Red" ControlToValidate="internshipClosingDate" runat="server" ErrorMessage="Closing Date is required!"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Openings Count:</td>
                    <td>
                        <asp:TextBox ID="internshipOpeningsCount" TextMode="Number" CssClass="form-control" style="margin-top: 20px;" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCount" runat="server" ForeColor="Red" ControlToValidate="internshipOpeningsCount" ErrorMessage="Enter the number of openings!"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidatorOpeningsCount" ControlToValidate="internshipOpeningsCount" Type="Integer" Operator="GreaterThan" ValueToCompare="0" runat="server" ErrorMessage="Invalid count of openings!" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Minimum Salary (per-month):</td>
                    <td>
                        <asp:TextBox ID="internshipMinSalary" TextMode="Number" CssClass="form-control" style="margin-top: 20px;" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMinSalary" ForeColor="Red" ControlToValidate="internshipMinSalary" runat="server" ErrorMessage="Enter the minimum salary"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidatorMinSalary" ControlToValidate="internshipMinSalary" Type="Integer" Operator="GreaterThan" ValueToCompare="0" runat="server" ErrorMessage="Invalid minimum salary!" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>

                <tr>
                    <td class="form-label">Maximum Salary (per-month):</td>
                    <td>
                        <asp:TextBox ID="internshipMaxSalary" TextMode="Number" CssClass="form-control" style="margin-top: 20px;" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMaxSalary" ForeColor="Red" ControlToValidate="internshipMaxSalary" runat="server" ErrorMessage="Enter a maximum salary!"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidatorMaxSalary" runat="server" ControlToValidate="internshipMaxSalary" Type="Integer" Operator="DataTypeCheck" ErrorMessage="Invalid Maximum Salary!" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnAddInternship" runat="server" Text="Add Internship" style="margin-bottom: 2vh;" Font-Size="Large" CssClass="btn btn-danger" OnClick="btnAddInternship_Click" />
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
