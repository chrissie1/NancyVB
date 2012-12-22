using System;
using Nancy.Authentication.Forms;
using Nancy.ModelBinding;
using Nancy;
using NancyDemo.Csharp.Services;

namespace NancyDemo.Csharp.Modules
{
    public class LoginModule: NancyModule
    {
        public LoginModule(UserService userService)
        {
            Get["/login"] = parameters => View["login.cshtml"];
            Post["/login"] = parameters =>
                {
                    var loginParams = this.Bind<LoginParams>();
                    var user = userService.AuthenticateUser(loginParams.Username, loginParams.Password);
                    if (user == null)
                    {
                        return "Your username and password were incorrect please enter a correct one.";
                    }
                    return this.LoginAndRedirect(user.Id);
                };
            Get["/logout"] = parameters => this.LogoutAndRedirect("~/");
        }
    }

    public class LoginParams
    {
        public String Username { get; set; }
        public String Password { get; set; }
    }
}