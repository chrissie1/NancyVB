@Inherits Nancy.ViewEngines.Razor.NancyRazorViewBase(Of WebApplication2.Model.TreesModel)

@Code
    ViewBag.Title = "Trees page"
    Layout = "Master.vbhtml"
End Code
@Section menu
    RenderSection("menu")
End Section

    <h1>Welcome to the trees page</h1>
    <p>There are @Model.NumberOfTrees trees in this collection.</p>
    <table>
        <tr><th>Id</th><th>Name</th></tr>
        @For Each tree As WebApplication2.Model.TreeModel In Model.Trees
            @<tr>
                <td>@tree.Id</td>
                <td><a href="/trees/@tree.Id">@tree.Genus</a></td>
            </tr>
        Next
    </table>
