<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Le Bank</h2>

<p>Welcome to le bank</p>

<% if (ViewData["IsAuthenticated"].ToString() == "True") { %>
    <a href="<%: Url.Action("Index", "Account") %>">Show accounts</a><br />
    <a href="<%: Url.Action("Index", "User") %>">Show profile</a><br />
<% } else { %>
    <a href="<%: Url.Action("Index", "Login") %>">Login</a>
<% } %>

</asp:Content>
