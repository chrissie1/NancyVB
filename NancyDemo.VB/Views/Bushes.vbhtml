@Inherits Nancy.ViewEngines.Razor.NancyRazorViewBase(Of NancyDemo.VB.Model.BushesModel)

@Code
    ViewBag.Title = "Bushes page"
    Layout = "Master.vbhtml"
End Code
@Section menu
    RenderSection("menu")
End Section

    <h1>Welcome to the bushes page</h1>
    <p>There are @Model.NumberOfBushes trees in this collection.</p>
    <table>
        <tr><th>Id</th><th>Name</th></tr>
        @For Each bush As NancyDemo.VB.Model.BushModel In Model.Bushes
            @<tr>
                <td>@bush.Id</td>
                <td><a href="/bushes/@bush.Id">@bush.Genus</a></td>
            </tr>
        Next
    </table>

<a href="/bushes/add/">Add a bush</a>
