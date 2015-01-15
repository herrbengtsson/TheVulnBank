<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<table class="tiger-table">
    <thead>
        <tr>
            <th>
                Name
            </th>
            <th>
                Amount
            </th>
            <th>
                &nbsp;
            </th>
        </tr>
    </thead>
    <tbody>
    <% foreach (TheVulnBank.Models.Data.Account account in Model) {  %>
        <tr>
            <td><%: account.Name %></td>
            <td><%: account.Amount %></td>
            <td><%: Html.ActionLink("Show transfers", "Transfers", new { id = account.Id }) %></td>
        </tr>
    <% } %>
    </tbody>
</table>

<a href="<%: Url.Action("Transfer", "Account") %>">New transfer</a>

</asp:Content>
