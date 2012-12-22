using System;
using System.Collections.Generic;
using System.Linq;
using NancyDemo.Csharp.Model;

namespace NancyDemo.Csharp.Services
{
    public class UserService
    {
        private readonly IList<UserModel> _users ;

        public UserService()
        {
            _users = new List<UserModel>();
            _users.Add(new UserModel
                {Id = new Guid("00000000000000000000000000000004"),
                     Name = "Chris1",
                     Password = "123",
                     RealName = "Christiaan Baes 1"
                });
            _users.Add(new UserModel
                {Id = new Guid("00000000000000000000000000000001"),
                     Name = "Chris2",
                     Password = "123",
                     RealName = "Christiaan Baes 2"
                });
            _users.Add(new UserModel
                {Id = new Guid("00000000000000000000000000000002"),
                     Name = "Chris3",
                     Password = "123",
                     RealName = "Christiaan Baes 3"
                });
            _users.Add(new UserModel
                {Id = new Guid("00000000000000000000000000000003"),
                     Name = "Chris4",
                     Password = "123",
                     RealName = "Christiaan Baes 4"
                });
        }

        public IList<UserModel> GetUsers()
        {
            return _users;
        }

        public UserModel AuthenticateUser(String username, String password)
        {
            var user = _users.SingleOrDefault(userModel => userModel.Name == username);
            if( user != null && !user.Password.Equals(password))
            {
                return null;
            }
            return user;
        }

        public UserModel GetById(Guid identifier)
        {
            return _users.SingleOrDefault(userModel => userModel.Id == identifier);
        }
    }
}
