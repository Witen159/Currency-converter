using System.Collections.Generic;
using CurrencyConverter.Core.Domains.Users.Repositories;

namespace CurrencyConverter.Core.Domains.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Get(string id)
        {
            return _userRepository.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Creat(User user)
        {
            throw new System.NotImplementedException();
        }

        public void Update(User user)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}