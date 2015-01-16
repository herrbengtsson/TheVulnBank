<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Login</h2>
    <p>Logga in för att komma åt dina sidor</p>

    <div class="login-box">
        <form action="<%: Url.Action("Index", "Login") %>" method="post">
            <%: TempData["Message"] %>
            <span>Användarnamn:</span>
            <input type="text" name="username" />
            <span>Lösenord:</span>
            <input type="password" name="password" />
            <button type="submit">Sign in!</button>
            <div class="clear"><!-- --></div>
        </form>
    </div>

</asp:Content>
