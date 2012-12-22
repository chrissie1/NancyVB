@Inherits Nancy.ViewEngines.Razor.NancyRazorViewBase(Of NancyDemo.VB.Model.UserModel)

@Code
    ViewBag.Title = "User page"
    Layout = "Master.vbhtml"
End Code

@Section menu
    RenderSection("menu")
End Section
@Section menuitems
    <a href="/users">Users</a>
End Section

    <h1>Welcome to the user page</h1>
    <table>
        <tr>
            <td>Id</td>
            <td>@Model.Id</td>
        </tr>
        <tr>
            <td>Genus</td>
            <td>@Model.Name</td>
        </tr>
        <tr>
            <td>Password</td>
            <td>@Model.Password</td>
        </tr>
    </table>

    
