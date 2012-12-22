@Inherits Nancy.ViewEngines.Razor.NancyRazorViewBase(Of NancyDemo.VB.Model.BushModel)

@Code
    ViewBag.Title = "Add bush page"
    Layout = "Master.vbhtml"
End Code

@Section menu
    RenderSection("menu")
End Section
@Section menuitems
    <a href="/bushes">Bushes</a>
End Section

    <h1>Welcome to the add bush page</h1>
    <form  action="/bushes/add/" method="post">
        <table>
            <tr>
                <td>Id</td>
                <td><input type="text" name="Id" value="@Model.Id" /></td>
            </tr>
            <tr>
                <td>Genus</td>
                <td><input type="text" name="Genus" value="@Model.Genus" /></td>
            </tr>
        </table>
        <input type="submit" value="Add new"/>
    </form>    
