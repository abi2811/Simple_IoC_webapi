using System.Collections.Generic;
using FirstMediatR.Model;

namespace FirstMediatR.Services.Interfaces
{
    public interface IUserService
    {
         void Add(string email, string password);
         User Get(string email);
         IEnumerable<User> GetAll();

    }
}