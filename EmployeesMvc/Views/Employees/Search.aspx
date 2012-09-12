<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Search
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Search results</h2>

    <div class="error"><%= ViewData["ErrorMessage"] %></div>

    <% if (ViewData["Results"] != null)
       { %>

        <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Job title</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var employee in (IList<EmployeesMvc.Model.Employee>)ViewData["Results"])
                   { %>
                <tr>
                    <td><%= employee.FirstName %>&nbsp;<%= employee.Surname %></td>
                    <td><%= employee.JobTitle.Name %></td>
                    <td><%= Html.ActionLink("edit", "Index", "Employee/Edit", new {EmployeeId = employee.Id}, string.Empty) %></td>
                </tr>
                <% } %>
            </tbody>
        </table>

       <% } %>

    <%= Html.ActionLink("Add new", "Index", "Employee") %>

    <%= Html.ActionLink("back", "Index") %>

</asp:Content>
