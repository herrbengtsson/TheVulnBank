<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<form action="<%: Url.Action("Index", "Login") %>" method="post">

    <%: TempData["Message"] %>

    <input type="text" name="username" />
    <input type="password" name="password" />
    <input type="submit" />

</form>

</asp:Content>
