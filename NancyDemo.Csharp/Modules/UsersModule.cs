using System;
using NancyDemo.Csharp.Model;
using Nancy;
using Nancy.Security;
using NancyDemo.Csharp.Services;

namespace NancyDemo.Csharp.Modules
{
    public class UsersModule : NancyModule
    {
        public UsersModule(UserService userService)
        {
            this.RequiresAuthentication();
            Get["/users"] = parameters => View[new UsersModel() {Users = userService.GetUsers()}];
            Get["/users/{Id}"] = parameters =>
                {
                    Guid result;
                    var isInteger = Guid.TryParse(parameters.id, out result);
                    var user = userService.GetById(result);
                    if (isInteger && user != null)
                    {
                        return View[user];
                    }
                    else
                    {
                        return HttpStatusCode.NotFound;
                    }
                };
        }
    }
}
