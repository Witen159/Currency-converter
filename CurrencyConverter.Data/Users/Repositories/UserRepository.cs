using System;
using System.Collections.Generic;
using System.Linq;
using CurrencyConverter.Core.Domains.Users;
using CurrencyConverter.Core.Domains.Users.Repositories;

namespace CurrencyConverter.Data.Users.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<UserEntity> _userEntities = new List<UserEntity>();
        public User Get(string id)
        {
            var entity = _userEntities.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return new User
            {
                Id = entity.Id,
                Login = entity.Login
            };
        }

        public IEnumerable<User> GetAll()
        {
            return _userEntities.Select(x => new User()
            {
                Id = x.Id,
                Login = x.Login
            });
        }

        public void Creat(User user)
        {
            var entity = new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                Login = user.Login,
                Password = user.Password,
                IsActive = false
            };
            
            _userEntities.Add(entity);
        }

        public void Update(User user)
        {
            var entity = _userEntities.FirstOrDefault(x => x.Id == user.Id);

            if (entity != null)
            {
                entity.Login = user.Login;
                entity.IsActive = user.IsActive;
            }
        }

        public void Delete(string id)
        {
            var entity = _userEntities.FirstOrDefault(x => x.Id == id);

            if (entity != null)
            {
                _userEntities.Remove(entity);
            }
        }
    }
}