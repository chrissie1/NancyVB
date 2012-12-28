using System;
using System.Collections.Generic;

namespace NancyDemo.Csharp.Model
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public IEnumerable<String> Claims { get; set; } 
        public String Password { get; set; }
        public String RealName { get; set; }
        public String FileDetails { get; set; }

        public UserModel()
        {
            Claims = new List<String>();
        }
    }
}
