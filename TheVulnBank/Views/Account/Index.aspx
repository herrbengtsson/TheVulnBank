<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<table>
    <thead>
        <tr>
            <th>
                Id
            </th>
            <th>
                User Id
            </th>
            <th>
                Amount
            </th>
        </tr>
    </thead>
    <tbody>
    <% foreach (TheVulnBank.Models.Data.Account account in Model) {  %>
        <tr>
            <td><a href="<%: Url.Action("Transfers", "Account", new { id = account.Id }) %>"><%: account.Id %></a></td>
            <td><%: account.UserId %></td>
            <td><%: account.Amount %></td>
        </tr>
    <% } %>
    </tbody>
</table>

<a href="<%: Url.Action("Transfer", "Account") %>">New transfer</a>

</asp:Content>
