using System;
using System.IO;
using System.Linq;
using Nancy.ModelBinding;
using NancyDemo.Csharp.Model;
using Nancy;
using Nancy.Security;
using NancyDemo.Csharp.Services;

namespace NancyDemo.Csharp.Modules
{
    public class UsersModule : NancyModule
    {
        public UsersModule(UserService userService, IRootPathProvider pathProvider)
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
            Get["/users/userimageupload/{Id}"] = parameters =>
            {
                Guid result;
                var isGuid = Guid.TryParse(parameters.id, out result);
                var user = userService.GetById(result);
                if (isGuid && user != null)
                {
                    return View["UploadUserImage",user];
                }
                return HttpStatusCode.NotFound;
            };
            Post["/users/userimageupload/{Id}"] = parameters =>
                {
                    Guid result;
                    var isGuid = Guid.TryParse(parameters.Id, out result);
                    var user = userService.GetById(result);
               
                    var file = this.Request.Files.FirstOrDefault();

                    if (isGuid && user != null && file != null)
                    {
                        var fileDetails = string.Format("{3} - {0} ({1}) {2}bytes", file.Name, file.ContentType, file.Value.Length, file.Key);
                        user.FileDetails = fileDetails;
                        var filename = Path.Combine(pathProvider.GetRootPath(), "Images", user.Id + ".jpeg");

                        using (var fileStream = new FileStream(filename, FileMode.Create))
                        {
                            file.Value.CopyTo(fileStream);
                        }
                        return View[user];
                    }
                    return HttpStatusCode.NotFound;
                };
            Get["/users/getimage/{Id}"] = parameters =>
                {
                    Guid result;
                    var isGuid = Guid.TryParse(parameters.Id, out result);
                    var filename = Path.Combine(pathProvider.GetRootPath(), "Images", result.ToString() + ".jpeg");
                    if (!File.Exists(filename)) filename = Path.Combine(pathProvider.GetRootPath(), "Images", "emptyuser.jpeg");
                    var stream = new FileStream(filename, FileMode.Open);
                    return Response.FromStream(stream, "image/jpeg");
                };
        }
    }
}
