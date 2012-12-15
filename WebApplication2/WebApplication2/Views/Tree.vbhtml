@Inherits Nancy.ViewEngines.Razor.NancyRazorViewBase(Of WebApplication2.Model.TreeModel)

@Code
    ViewBag.Title = "Tree page"
    Layout = "Master.vbhtml"
End Code

@Section menu
    RenderSection("menu")
End Section
@Section menuitems
    <a href="/trees">Trees</a>
End Section

    <h1>Welcome to the tree page</h1>
    <table>
        <tr>
            <td>Id</td>
            <td>@Model.Id</td>
        </tr>
        <tr>
            <td>Genus</td>
            <td>@Model.Genus</td>
        </tr>
    </table>

    
