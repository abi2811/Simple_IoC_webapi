using System.Collections.Generic;
using System.Threading.Tasks;
using FirstMediatR.DTO;
using FirstMediatR.Model;

namespace FirstMediatR.Data.Interfaces
{
    public interface IUserRepository
    {
         void Add(User user);
         User Get(string email);
         IEnumerable<User> GetAll();
    }
}