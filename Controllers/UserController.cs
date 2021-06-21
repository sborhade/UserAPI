using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserAPI.Models;
using UserAPI.Repository;

namespace UserAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly ILogger<UserController> _logger;
		private readonly IUserRepository repository;

		private readonly UserContext _context;

		public UserController(ILogger<UserController> logger, UserContext context, IUserRepository _repository)
		{
			_logger = logger;
			_context = context;
			repository = _repository;
		}


		[HttpGet]
		public IEnumerable<User> Get() => repository.GetAll();

		// GET: api/User/Name
		[HttpGet("{FullName}")]
		public async Task<ActionResult<User>> GetUser(string FullName)
		{
			if (string.IsNullOrEmpty(FullName))
				return BadRequest("Value must be passed in the request body.");
			return Ok(repository.Find(FullName));

		}

		[HttpPost]
		public User Post([FromBody] User res)
		{
			repository.Add(new User
			{
				FullName = res.FullName,
				Phone = res.Phone,
				Age = res.Age,
				Email = res.Email
			});
            return res;

		}
		/*[HttpPost]
        public IActionResult Post([FromBody] User res)
        {
            if (!Authenticate())
                return Unauthorized();
            return Ok(repository.AddUser(new User
            {
                FullName = res.FullName,
                Phone = res.Phone,
                Email = res.Email
            }));
        }*/

		[HttpPut]
		public User Put([FromForm] User res)
		{
			repository.Update(res);
            return res;
		} 

		[HttpDelete("{FullName}")]
		public void Delete(string FullName) => repository.Remove(FullName);

		[HttpGet("ShowUser.{format}"), FormatFilter]
		public IEnumerable<User> ShowUser() => repository.GetAll();
	}
}
