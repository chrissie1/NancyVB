using System;
using System.Collections.Generic;
using Nancy.Security;

namespace NancyDemo.Csharp.Security
{
    public class AuthenticatedUser : IUserIdentity
    {
        public String UserName { get; set; }
        public IEnumerable<String> Claims { get; set; } 
        public String RealName { get; set; }
    }
}