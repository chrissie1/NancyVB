@Inherits Nancy.ViewEngines.Razor.NancyRazorViewBase(Of WebApplication2.Model.TreeModel)

@Code
    ViewBag.Title = "Add tree page"
    Layout = "Master.vbhtml"
End Code

@Section menu
    RenderSection("menu")
End Section
@Section menuitems
    <a href="/trees">Trees</a>
End Section

    <h1>Welcome to the add tree page</h1>
    <form  action="/trees/add/" method="post">
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
