<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/organisation/organisation.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="InternHub.organisation.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        td {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            
        <div>
        <h2 style="text-align: center; margin: 3vh 0 3vh 0;">Your Internships</h2>
        <div class="table-responsive">
        <asp:GridView ID="orgInternships" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CssClass="table table-hover" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:BoundField DataField="internship_id" Visible="false" HeaderText="Internship Id" SortExpression="internship_id" />
                <asp:BoundField DataField="row_id" HeaderText="#" SortExpression="row_id" />

                <asp:TemplateField HeaderText="Internship">
                    <ItemTemplate>
                        <asp:HyperLink ID="linkInternship" runat="server" NavigateUrl='<%# string.Format("~/ShowInternships?stream={0}#MainContent_{0}-internship-{1}", HttpUtility.UrlEncode(Eval("stream").ToString()), HttpUtility.UrlEncode(Eval("internship_id").ToString())) %>' Text='<%# Eval("job_title") %>'>HyperLink</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="stream" HeaderText="Stream" SortExpression="stream" />
                

                
                <asp:BoundField DataField="closing_date" HeaderText="Closing Date" SortExpression="closing_date" />
                <asp:BoundField DataField="openings" HeaderText="Openings" SortExpression="openings" />
                <asp:BoundField DataField="pending_applications" HeaderText="Pending Applications" SortExpression="pending_applications" />
                <asp:BoundField DataField="confirmed_interns" HeaderText="Confirmed Interns" SortExpression="confirmed_interns" />
                
                <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnEditInternship" CssClass="btn btn-warning" OnCommand="btnActionInternship" CommandName="Edit" runat="server" Text="Edit" CommandArgument='<%# Eval("internship_id") %>' UseSubmitBehavior="False" />
                            <asp:Button ID="btnDeleteInternship" CssClass="btn btn-danger" OnCommand="btnActionInternship" CommandName="Delete" runat="server" Text="Delete" CommandArgument='<%# Eval("internship_id") %>' UseSubmitBehavior="False" />
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

    </div>

    <script>
        var x = document.getElementsByTagName("th");
        for (var i = 0; i < x.length; i++) {
            x[i].style.textAlign = "center";
        }
    </script>

</asp:Content>
