using System;
using Nancy.Authentication.Forms;
using NancyDemo.Csharp.Services;

namespace NancyDemo.Csharp.Security
{
    public class FakeUserMapper :IUserMapper
    {
        private readonly UserService _userService;

        public FakeUserMapper(UserService userService)
        {
            _userService = userService;
        }


        public Nancy.Security.IUserIdentity GetUserFromIdentifier(Guid identifier, Nancy.NancyContext context)
        {
            var user = _userService.GetById(identifier);
            return new AuthenticatedUser
                {
                    UserName = user.Name,
                    Claims = user.Claims,
                    RealName = user.RealName
                };
        }

    }
}
