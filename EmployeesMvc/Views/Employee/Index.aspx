<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <% using (Html.BeginForm("Add", "Employee"))
       {%>
    <p>First name: <%= Html.TextBox("firstname") %></p>
    <p>Surname: <%= Html.TextBox("surname") %></p>
    <p>Job title: <%= Html.DropDownList("jobTitles")%></p>
    <input type="submit" value="Add" />
    <% } %>
</asp:Content>
