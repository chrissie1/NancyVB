@Code
    ViewBag.Title = "Index page"
    Layout = "Master.vbhtml"
End Code

    <form method="POST">
        Username <input type="text" name="Username" />
        <br />
        Password <input name="Password" type="password" />
        <br />
        Remember Me <input name="RememberMe" type="checkbox" value="True" />
        <br />
        <input type="submit" value="Login" />
    </form>