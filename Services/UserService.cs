using System.Collections.Generic;
using FirstMediatR.Data.Interfaces;
using FirstMediatR.Model;
using FirstMediatR.Services.Interfaces;

namespace FirstMediatR.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public void Add(string email, string password)
        {
            _repository.Add(new User(email, password));
        }

        public User Get(string email)
        {
            var user = _repository.Get(email);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _repository.GetAll();
            return users;
        }
    }
}