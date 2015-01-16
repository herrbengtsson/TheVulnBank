<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<img src="<%: Request.Url.AbsolutePath.ToString() %>Show/Img/?file=1065245_79106935.jpg&width=200&height=200" style="float: right; margin: -15px;" />

<h2>Welcome to your totally trustworthy bank site!</h2>

<p>
    Ever heard of XSS, CSRF or SQL Injection? Neither have we! But we don't really care
    about all that mombo jumbo, all we care about is your money. And boy, we're gonna get rich -
    you and I!
</p>

<p><i>The vulnerable bank - where every bug is a feature</i></p>

<div class="clear"><!-- --></div>

</asp:Content>
