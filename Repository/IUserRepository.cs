using System.Collections.Generic;
using UserAPI.Models;

namespace UserAPI.Repository
{
    public interface IUserRepository
    {
        void Add(User item);
        IEnumerable<User> GetAll();
        User Find(string key);
        User Remove(string key);
        void Update(User item);
    }
}
