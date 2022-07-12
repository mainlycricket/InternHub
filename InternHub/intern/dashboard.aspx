<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/intern/intern.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="InternHub.intern.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        td {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
    <div>
        <!-- <asp:Label ID="greet" runat="server" Text=""></asp:Label> <br />
        <asp:Label ID="warning" runat="server" Text="Label"></asp:Label> 
        <asp:HyperLink ID="linkEditProfile" runat="server" NavigateUrl="~/intern/EditProfile.aspx">Edit Profile</asp:HyperLink>
        <asp:HyperLink ID="linkViewProfile" runat="server" NavigateUrl="~/intern/ViewProfile.aspx">View Profile</asp:HyperLink> -->
    </div>
    <div>
        <h2 style="text-align: center; margin: 3vh 0 3vh 0;">Your Internships</h2>
        <div class="table-responsive">
        <asp:GridView ID="internInternships" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CssClass="table table-hover" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:BoundField DataField="internship_id" Visible="false" HeaderText="Internship Id" SortExpression="internship_id" />
                <asp:BoundField DataField="row_id" HeaderText="#" SortExpression="row_id" />

                <asp:TemplateField HeaderText="Internship">
                    <ItemTemplate>
                        <asp:HyperLink ID="linkInternship" runat="server" NavigateUrl='<%# string.Format("~/ShowInternships?stream={0}#MainContent_{0}-internship-{1}", HttpUtility.UrlEncode(Eval("stream").ToString()), HttpUtility.UrlEncode(Eval("internship_id").ToString())) %>' Text='<%# Eval("job_title") %>'>HyperLink</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="stream"  Visible="false" HeaderText="Stream" SortExpression="stream" />
                <asp:HyperLinkField DataNavigateUrlFields="org_id" DataNavigateUrlFormatString="~/ViewOrg?id={0}" DataTextField="org_name" HeaderText="Organisation" />
                <asp:BoundField DataField="org_id"  Visible="false" HeaderText="Organisation Id" SortExpression="org_id" />

                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:HyperLink ID="linkMail" runat="server" NavigateUrl='<%# string.Format("mailto:{0}", Eval("org_email")) %>' Text='<%# Eval("org_email") %>' ></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                
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

        var td_cell = document.getElementsByTagName("td");
        for (var i = 0; i < td_cell.length; i++) {
            td_cell[i].style.marginTop = "5px";
            if (td_cell[i].innerText == "Confirmed") {
                td_cell[i].className = "badge text-bg-success";
            } else if (td_cell[i].innerText == "Pending") {
                td_cell[i].className = "badge text-bg-warning";
            } else if (td_cell[i].innerText == "Rejected") {
                td_cell[i].className = "badge text-bg-danger";
            }
        }

        var x = document.getElementsByTagName("th");
        for (var i = 0; i < x.length; i++) {
            x[i].style.textAlign = "center";
        }

    </script>
</asp:Content>
