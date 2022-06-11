﻿using System.Collections.Generic;

namespace CurrencyConverter.Core.Domains.Users.Services
{
    public interface IUserService
    {
        User Get(string id);
        IEnumerable<User> GetAll();
        void Creat(User user);
        void Update(User user);
        void Delete(string id);
    }
}