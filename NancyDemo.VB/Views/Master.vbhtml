<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
</head>
<body>
    <div id="menu">
    @If Url.RenderContext.Context.CurrentUser Is Nothing Then 
        @<a href="/login">Login</a>
    Else
        @Url.RenderContext.Context.CurrentUser.UserName  
        @<a href="/logout">Logout</a>
    End If
    @If IsSectionDefined("menu") Then
        @<a href="/">Index</a>
        @If IsSectionDefined("menuitems") Then
            @RenderSection("menuitems")
        End if
    End If
    </div>
    
    @RenderBody()
</body>
</html>
