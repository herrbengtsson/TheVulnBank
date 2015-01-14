<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<% foreach (TheVulnBank.Controllers.Account account in Model) {  %>

    <a href="<%: Url.Action("Transfers", "Account", new { accountId = account.Id }) %>"><%: account.Id %> : <%: account.UserId %> : <%: account.Amount %></a><br />

<% } %>

</asp:Content>
