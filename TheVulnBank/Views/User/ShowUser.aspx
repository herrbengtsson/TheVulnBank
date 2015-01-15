<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TheVulnBank.Models.Data.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>View</h2>

<b>Username:</b> <%: Model.Username %><br />
<b>First name:</b> <%: Model.FirstName %><br />
<b>Last name:</b> <%: Model.LastName %><br />

<a href="<%: Url.Action("ChangePassword", "User") %>">Change password</a>

</asp:Content>
