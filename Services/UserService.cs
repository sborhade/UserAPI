using UserAPI.Models;
using System.Collections.Generic;
using System.Linq;
using UserAPI.Models;
namespace UserAPI.Services
{
	public class UserService : IUserService
	{
		public List<User> Users { get; }

		public UserService()
		{
			Users = new List<User>
			{
				new User { Age = 31, FullName = "Peter", Email = "peter@ms.com" },
				new User { Age = 23, FullName = "Ross", Email = "Ross@ms.com" }
			};
		}

		public List<User> GetAll() => Users;

		public  User Get(string FullName) => Users.FirstOrDefault(p => p.FullName == FullName);

		public  void Add(User User)
		{
			Users.Add(User);
		}

		public  void Delete(string FullName)
		{
			var User = Get(FullName);
			if (User is null)
				return;

			Users.Remove(User);
		}

		public  void Update(User User)
		{
			var index = Users.FindIndex(p => p.FullName == User.FullName);
			if (index == -1)
				return;

			Users[index] = User;
		}
	}
}
