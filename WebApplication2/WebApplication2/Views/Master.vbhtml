<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
</head>
<body>
    @If IsSectionDefined("menu") Then
        @<div id="menu"><a href="/">Index</a>
        @If IsSectionDefined("menuitems") Then
            @RenderSection("menuitems")
        End if
        </div>
    End if
    
    
    @RenderBody()
</body>
</html>
