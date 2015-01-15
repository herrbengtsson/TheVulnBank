<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TheVulnBank.Models.View.Account>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Transfers</h2>

<table class="tiger-table">
    <thead>
        <tr>
            <th>
                Id
            </th>
            <th>
                From account
            </th>
            <th>
                To account
            </th>
            <th>
                Amount
            </th>
            <th>
                Message
            </th>
        </tr>
    </thead>
    <tbody>
    <% foreach (TheVulnBank.Models.Data.Transfer transfer in Model.Transfers) {  %>
        <tr>
            <td><%: transfer.Id %></td>
            <td><%: Model.Accounts.First(a => a.Id == transfer.FromAccountId).Name %></td>
            <td><%: Model.Accounts.First(a => a.Id == transfer.ToAccountId).Name %></td>
            <td><%: transfer.Amount %></td>
            <td><%: transfer.Message %></td>
        </tr>
    <% } %>
    </tbody>
</table>

<a href="<%: Url.Action("Transfer", "Account") %>">New transfer</a>

</asp:Content>
