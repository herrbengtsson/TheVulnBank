<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Transfers</h2>

<% foreach (TheVulnBank.Controllers.Transfer transfer in Model) {  %>

    <%: transfer.Id %> : <%: transfer.SendAccId %> : <%: transfer.RecAccId %> : <%: transfer.Amount %> : <%: transfer.Message %><br />

<% } %>

</asp:Content>
