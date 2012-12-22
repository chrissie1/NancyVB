@Inherits Nancy.ViewEngines.Razor.NancyRazorViewBase(Of NancyDemo.VB.Model.UsersModel)

@Code
    ViewBag.Title = "Users page"
    Layout = "Master.vbhtml"
End Code
@Section menu
    RenderSection("menu")
End Section

    <h1>Welcome to the users page</h1>
    <table>
        <tr><th>Id</th><th>Name</th><th>Name</th><th>password</th></tr>
        @For Each user As NancyDemo.VB.Model.UserModel In Model.Users
            @<tr>
                <td>@user.Id</td>
                <td><a href="/users/@user.Id">@user.Name</a></td>
                <td>@user.RealName</td>
                <td>@user.Password</td>
            </tr>
        Next
    </table>

