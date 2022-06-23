﻿using System;
using System.Collections.Generic;
using System.Linq;
using CurrencyConverter.Core.Domains.Users;
using CurrencyConverter.Core.Domains.Users.Repositories;

namespace CurrencyConverter.Data.Users.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConverterContext _context;

        public UserRepository(ConverterContext context)
        {
            _context = context;
        }

        public User Get(string id)
        {
            var entity = _context.Users.FirstOrDefault(x => x.Id == id);

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
            return _context.Users.Select(x => new User()
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
            
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            var entity = _context.Users.FirstOrDefault(x => x.Id == user.Id);

            if (entity != null)
            {
                entity.Login = user.Login;
                entity.IsActive = user.IsActive;
            }

            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = _context.Users.FirstOrDefault(x => x.Id == id);

            if (entity != null)
            {
                _context.Users.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}