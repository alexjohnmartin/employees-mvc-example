<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm("Save", "Employee"))
       {%>

    <p>First name: <%= Html.TextBox("firstname", (ViewData["Employee"] as EmployeesMvc.Model.Employee).FirstName) %></p>
    <p>Surname: <%= Html.TextBox("surname", (ViewData["Employee"] as EmployeesMvc.Model.Employee).Surname) %></p>
    <p>Job title: <%= Html.DropDownList("jobTitles", (ViewData["Employee"] as EmployeesMvc.Model.Employee).JobTitle.Name) %></p>
    <%= Html.Hidden("Id", (ViewData["Employee"] as EmployeesMvc.Model.Employee).Id) %>
    <input type="submit" value="Save" />
    <% } //form %>
</asp:Content>
