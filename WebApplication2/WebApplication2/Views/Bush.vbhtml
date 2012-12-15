@Inherits Nancy.ViewEngines.Razor.NancyRazorViewBase(Of WebApplication2.Model.BushModel)

@Code
    ViewBag.Title = "Bush page"
    Layout = "Master.vbhtml"
End Code

@Section menu
    RenderSection("menu")
End Section
@Section menuitems
    <a href="/bushes">Bushes</a>
End Section

    <h1>Welcome to the bush page</h1>
    <table>
        <tr>
            <td>Id</td>
            <td>@Model.Id</td>
        </tr>
        <tr>
            <td>Name</td>
            <td>@Model.Genus</td>
        </tr>
    </table>

    
