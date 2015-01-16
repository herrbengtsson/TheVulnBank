<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TheVulnBank.Models.View.Transfer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>New transfer</h2>

<form action="<%= Request.RawUrl %>" method="post">
    From: <select name="fromAccountId">
        <% foreach (TheVulnBank.Models.Data.Account fromAccount in Model.FromAccounts)
           { %>
            <option value="<%: fromAccount.Id %>"><%: fromAccount.Name %> - <%: fromAccount.Amount %></option>
        <% } %>
    </select><br />

    To: <select name="toAccountId">
        <% foreach (TheVulnBank.Models.Data.Account toAccount in Model.ToAccounts) { %>
            <option value="<%: toAccount.Id %>"><%: toAccount.Name %></option>
        <% } %>
    </select><br />
    Amount: <input type="text" name="amount" /><br />
    Message: <input type="text" name="message" /><br />
    <input type="submit" />
</form>

</asp:Content>
