<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Common Questions & Answers</h2>
        <div class="question-item-container">
            <div class="question-item">
                <div class="question-title"><span class="question-circle">?</span><span class="question-text">Olle! Är jag en björn?</span></div>
                <div class="question-answer">
                    <span style="font-weight: bold;">Svar:</span>
                    <span>Du är en snel hest.</span>
                </div>
            </div>
            <div class="question-item">
                <div class="question-title"><span class="question-circle">?</span><span class="question-text">Olle! Är jag en björn?</span></div>
                <div class="question-answer">
                    <span style="font-weight: bold;">Svar:</span>
                    <span>Du är en snel hest.</span>
                </div>
            </div>
            <div class="question-item">
                <div class="question-title"><span class="question-circle">?</span><span class="question-text">Olle! Är jag en björn?</span></div>
                <div class="question-answer">
                    <span style="font-weight: bold;">Svar:</span>
                    <span>Du är en snel hest.</span>
                </div>
            </div>
        </div>

        <h2>Have another question? Ask it!</h2>
        <p>We will answer asap!</p>

        <div class="question-textbox">
            <% using (Html.BeginForm("Index", "Contact", FormMethod.Post)) %>
            <% { %>
            <textarea name="q" rows="5"></textarea>
            <button type="submit">Fråga</button>
            <% } %>
            <div class="clear">
                <!-- -->
            </div>
        </div>

        <div class="question-item-container">
            <div class="question-item">
                <div class="question-title"><span class="question-circle">?</span><span class="question-text">Olle! Är jag en björn?</span></div>
                <div class="question-answer">
                    <span style="font-weight: bold;">Svar:</span>
                    <span>Du är en snel hest.</span>
                </div>
            </div>
            <div class="question-item">
                <div class="question-title"><span class="question-circle">?</span><span class="question-text">Olle! Är jag en björn?</span></div>
                <div class="question-answer">
                    <span style="font-weight: bold;">Svar:</span>
                    <span>Du är en snel hest.</span>
                </div>
            </div>
            <div class="question-item">
                <div class="question-title"><span class="question-circle">?</span><span class="question-text">Olle! Är jag en björn?</span></div>
                <div class="question-answer">
                    <span style="font-weight: bold;">Svar:</span>
                    <span>Du är en snel hest.</span>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
