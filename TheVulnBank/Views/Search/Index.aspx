<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TheVulnBank.Models.View.SearchResult>" %>
=======
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TheVulnBank.Models.View.Search>" %>
>>>>>>> 3160e5267fd563027584b9f4fde5688474ede8bc

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
<%--
        <h2>Search results</h2>        
        <div class="search-box">
            <div class="large-search">
                <form action="" method="get" accesskey="s" accept-charset="utf-8">
                    <input type="text" name="q" value="<%= Model.Query %>" autocomplete="false" /><input type="submit" value="Search" />
                </form>
            </div>
        </div>
        <% if (Model.Articles.Count == 0) { %>
            <p>No search results for <b><%= Model.Query %></b></p>
        <% } else { %>
            <p>Search results for <b><%= Model.Query %></b>:</p>
            <% foreach(TheVulnBank.Models.Data.Article article in Model.Articles) { %>
                <hr />
                <b><a href="<%: Url.Action("Index", "Article", new { id = article.Id }) %>"><%: article.Title %></a></b>
                <p><%: Html.SearchDescription(article.Text, Model.Query) %></p>
            <% } %>
        <% } %>
--%>
    

    <script type="text/html">
        <!-- TODO: Add DOM-based example -->
    </script>

</asp:Content>
