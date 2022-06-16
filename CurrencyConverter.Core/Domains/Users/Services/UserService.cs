using System;
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
            return _userRepository.GetAll();
        }

        public void Create(User user)
        {
            if (user.Login == null || user.Login.Length > 20)
            {
                throw new Exception("Incorrect login");
            }
            _userRepository.Creat(user);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public void Delete(string id)
        {
            _userRepository.Delete(id);
        }

        public void SerActive(string id)
        {
            var user = _userRepository.Get(id);

            if (user == null)
            {
                return;
            }

            if (user.IsActive)
            {
                throw new Exception("User is already active");
                return;
            }
            else
            {
                user.IsActive = true;
            }
            
            _userRepository.Update(user);
        }
    }
}