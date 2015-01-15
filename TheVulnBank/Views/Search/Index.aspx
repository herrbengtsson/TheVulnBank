<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h2>Sökresultat</h2>        
        <div class="search-box">
            <div class="large-search">
                <form action="" method="get" accesskey="s" accept-charset="utf-8">
                    <input type="text" name="q" value="<%= ViewData["Search"] %>" autocomplete="false">
                    <button type="submit">Sök</button>
                </form>
            </div>
        </div>
        <p>Inget sökresultat matchade <b><%= ViewData["Search"] %></b></p>
    </div>

    <script type="text/html">
        <!-- TODO: Add DOM-based example -->
    </script>

</asp:Content>
