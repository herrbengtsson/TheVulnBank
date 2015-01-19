<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TheVulnBank.Models.View.SearchResult>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h2>Sökresultat</h2>
        <div class="search-box">
            <div class="large-search">
                <form action="" method="get" accesskey="s" accept-charset="utf-8">
                    <input type="text" name="q" value="<%= ViewData["Search"] %>" autocomplete="false">
                    <input type="hidden" name="noOfItems" value="5">
                    <button type="submit">Sök</button>
                </form>
            </div>
        </div>
    </div>

    <div class="search-result-container">
        <% if (ViewData["Error"] != null) { %>
            <p style="color:red;"><%: ViewData["Error"] %></p>
        <% } else if (Model.Items.Count == 0) {%>
            <p>Inget sökresultat matchade <b><%= ViewData["Search"] %></b></p>
        <% } else { %>
        <% foreach (TheVulnBank.Models.Data.SearchItem item in Model.Items) { %>
            <div class="search-result-item">
                <p><a href="<%:item.Url %>" style="font-weight:bold; text-decoration:none;"><%:item.Summary.Length < 20 ? item.Summary : item.Summary.Substring(0,20) + "..." %></a></p>
                <div><%:item.Summary %></div>
            </div>
            <hr />
        <% }
           }%>
    </div>

    <script type="text/html">
        <!-- TODO: Add DOM-based example -->
    </script>

</asp:Content>
