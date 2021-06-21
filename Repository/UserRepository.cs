using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using UserAPI.Models;

namespace UserAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private static ConcurrentDictionary<string, User> _Users = 
              new ConcurrentDictionary<string, User>();

        public UserRepository()
        {
            Add(new User { FullName = "Item1" });
        }

        public IEnumerable<User> GetAll()
        {
            return _Users.Values;
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
