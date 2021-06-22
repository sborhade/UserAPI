using UserAPI.Models;
using System.Collections.Generic;
namespace UserAPI.Services
{
	public interface IUserService
	{
		List<User> Users { get; }

		public List<User> GetAll();

		public User Get(string FullName);

		public void Add(User User);

		public void Delete(string FullName);

		public void Update(User User);
	}
}