using System.Collections.Generic;

namespace CurrencyConverter.Core.Domains.Users.Repositories
{
    public interface IUserRepository
    {
        User Get(string id);
        IEnumerable<User> GetAll();
        void Creat(User user);
        void Update(User user);
        void Delete(string id);
    }
}