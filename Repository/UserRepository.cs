using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using UserAPI.Models;

namespace UserAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        UserContext _Users;

        public UserRepository(IUserContext Users)
        {
            _Users = Users;
        }

        public IEnumerable<User> GetAll()
        {
            if (_Users != null)
            {
                return await _Users.Users.ToListAsync();
            }

            return null;
        }

        public void Add(User  item)
        {
            _Users.TryAdd(item);
        }

        public User Find(string key)
        {
            User item;
            _Users.TryGetValue(key, out item);
            return item;
        }

        public User Remove(string key)
        {
            User item;
            _Users.TryGetValue(key, out item);
            _Users.TryRemove(key, out item);
            return item;
        }

        public void Update(User item)
        {
            _Users[item.Key] = item;
        }
    }
}
