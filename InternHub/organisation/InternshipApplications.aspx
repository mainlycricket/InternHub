<%@ Page Title="Internship Applications" Language="C#" MasterPageFile="~/organisation/organisation.Master" AutoEventWireup="true" CodeBehind="InternshipApplications.aspx.cs" Inherits="InternHub.organisation.InternshipApplications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        td {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <h2 style="text-align: center; margin: 3vh 0 3vh 0;">Internship Applications</h2>

        <div class="table-responsive">

            <asp:GridView ID="GridViewApplicants" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CssClass="table table-hover" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="None" AutoGenerateColumns="False">
                <Columns>

                    <asp:BoundField DataField="row_id" HeaderText="#" SortExpression="row_id" />

                    <asp:BoundField DataField="internshipId" Visible="false" HeaderText="Internship Id" SortExpression="internshipId" />
                    <asp:BoundField DataField="ApplicantId" Visible="false" HeaderText="Applicant Id" SortExpression="ApplicantId" />

                    <asp:TemplateField HeaderText="Internship">
                        <ItemTemplate>
                            <asp:HyperLink ID="linkInternship" runat="server" NavigateUrl='<%# string.Format("~/ShowInternships?stream={0}#MainContent_{0}-internship-{1}", HttpUtility.UrlEncode(Eval("stream").ToString()), HttpUtility.UrlEncode(Eval("internshipId").ToString())) %>' Text='<%# Eval("internshipCol") %>'>HyperLink</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="stream"  Visible="false" HeaderText="Stream" SortExpression="stream" />

                    <asp:BoundField DataField="ApplicantCol" HeaderText="Applicant Name" SortExpression="ApplicantCol" />
                    <asp:HyperLinkField DataNavigateUrlFields="PortfolioCol" Target="_blank" HeaderText="Applicant Portfolio" Text="View Portfolio" />
                    <asp:HyperLinkField DataNavigateUrlFields="ResumeCol" Target="_blank" DataNavigateUrlFormatString="~/intern/assests/uploads/resumes/{0}" HeaderText="Applicant Resume" Text="View Resume" />
                    <asp:HyperLinkField DataNavigateUrlFields="ProfileCol" Target="_blank" DataNavigateUrlFormatString="~/organisation/ViewIntern.aspx?id={0}" HeaderText="Applicant Profile" Text="View Profile" />
                    
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnAcceptIntern" CssClass="btn btn-success" OnCommand="btnActionApplication" CommandName="Accept" runat="server" Text="Accept" CommandArgument='<%# Eval("applicantId") + "-" + Eval("internshipId") %>' UseSubmitBehavior="False" />
                            <asp:Button ID="btnRejectIntern" CssClass="btn btn-danger" OnCommand="btnActionApplication" CommandName="Reject" runat="server" Text="Reject" CommandArgument='<%# Eval("applicantId") + "-" + Eval("internshipId")  %>' UseSubmitBehavior="False" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>

        </div>

    <script type="text/javascript">
        var x = document.getElementsByTagName("th");
        for (var i = 0; i < x.length; i++) {
            x[i].style.textAlign = "center";
        }
    </script>

</asp:Content>
