<%@ Page Title="Guidelines" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="guidelines.aspx.cs" Inherits="InternHub.guidelines" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 style="text-align: center; text-decoration: underline; margin: 5px 0 5px 0">Guidelines</h2>

    <ul class="nav nav-tabs">
  <li class="nav-item">
    <span class="nav-link active" id="intern-tab" style="color: black;" onclick="showIntern()">Interns</span>
  </li>
  <li class="nav-item">
    <span class="nav-link" id="org-tab" onclick="showOrg()">Organisation</span>
  </li>
 
</ul>

    <div id="intern-guidelines">
        <ul>
            <li>
                After registering themselves, the interns can log into their dashboards where they can edit their profiles.
            </li>
            <li>
                While editing their profiles, the interns are asked to fill up their personal, educational and contact details.
            </li>
            <li>
                Interns also enjoy the luxury of uploading their photos and resumes.
            </li>
            <li>
                Interns can use their LinkedIn or GitHub profiles, and even blog links, as their portfolio.
            </li>
            <li>
                Interns are recommended to fill in all the details before applying for internships.
            </li>
            <li>
                Interns can also view the profiles of the organisations to know more about them before applying.
            </li>
            <li>
                Interns are advised to check the status of their applications at regular intervals.
            </li>
        </ul>
    </div>

    <div id="org-guidelines">
        <ul>
            <li>
                After registering themselves, the organisations can log into their dashboards where they can edit their profiles.
            </li>
            <li>
                While editing their profiles, the organisations are asked to fill up some details.
            </li>
            <li>
                Organisations also enjoy the luxury of uploading their logos.
            </li>
            <li>
                Organisations are recommended to fill in all the details before publishing any internships.
            </li>
            <li>
                Organisations can also view the detailed profiles of the applicant interns.
            </li>
            <li>
                Organisations are advised to approve and reject interns as early as possible.
            </li>
        </ul>
    </div>

    <script>

        function showIntern() {
            document.getElementById("intern-guidelines").style.display = "block";
            document.getElementById("org-guidelines").style.display = "none";
            document.getElementById("intern-tab").className = "nav-link active";
            document.getElementById("org-tab").className = "nav-link";
            document.getElementById("intern-tab").style.color = "black";
        }

        function showOrg() {
            document.getElementById("org-guidelines").style.display = "block";
            document.getElementById("intern-guidelines").style.display = "none";
            document.getElementById("org-tab").className = "nav-link active";
            document.getElementById("intern-tab").className = "nav-link";
            document.getElementById("intern-tab").style.color = "blue";
        }


    </script>

</asp:Content>
