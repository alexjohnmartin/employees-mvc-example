<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <div class="error">
        <p><%: ViewData["message"] %></p>
    </div>

    <% using(Html.BeginForm("Search", "Employees")) %>
    <% { //form %>

    <p>Name: <%= Html.TextBox("name")%></p>
    <p>Job title: <%= Html.DropDownList("jobTitles")%></p>
    <p>
    <%--<%= Html.DropDownListFor(model => model.JobTitle, (ViewData["JobTitles"] as SelectList)) %>--%>
    </p>
    <input type="submit" value="Search" />
    <% } //form %>

</asp:Content>
