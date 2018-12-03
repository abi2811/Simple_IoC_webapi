using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstMediatR.Data.Factories;
using FirstMediatR.Data.Interfaces;
using FirstMediatR.DTO;
using FirstMediatR.Model;

namespace FirstMediatR.Data
{
    public class InMemoryUserRepository : IUserRepository
    {
        private ISet<User> _userList = UserListFactory.CreateUserList();
        public InMemoryUserRepository()
        {
            _userList.Add(new User("user1@email.com", "secret"));
            _userList.Add(new User("user2@email.com", "secret"));
            _userList.Add(new User("user3@email.com", "secret"));
        }

        public void Add(User user)
        {
            _userList.Add(user);
        }

        public User Get(string email)
        {
            var user = _userList.FirstOrDefault(x => x.Email == email);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _userList.ToList();
            return users;
        }
    }
}