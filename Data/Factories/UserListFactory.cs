using System.Collections.Generic;
using FirstMediatR.Model;

namespace FirstMediatR.Data.Factories
{
    public static class UserListFactory
    {
        public static HashSet<User> CreateUserList()
        {
            return new HashSet<User>();
        }
    }
}