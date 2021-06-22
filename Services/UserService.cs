using UserAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserAPI.Services
{
    public static class UserService
    {
        static List<User> Users { get; }
        
        static UserService()
        {
            Users = new List<User>
            {
                new User { Age = 31, FullName = "Peter", Email = "peter@ms.com" },
                new User { Age = 23, FullName = "Ross", Email = "Ross@ms.com" }
            };
        }

        public static List<User> GetAll() => Users;

        public static User Get(int id) => Users.FirstOrDefault(p => p.Id == id);

        public static void Add(User User)
        {
            User.Id = nextId++;
            Users.Add(User);
        }

        public static void Delete(int id)
        {
            var User = Get(id);
            if(User is null)
                return;

            Users.Remove(User);
        }

        public static void Update(User User)
        {
            var index = Users.FindIndex(p => p.Id == User.Id);
            if(index == -1)
                return;

            Users[index] = User;
        }
    }
}
