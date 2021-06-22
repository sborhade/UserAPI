using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAPI.Models;
using Microsoft.AspNetCore.Authorization;
 
namespace UserService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
 
        public UserController(UserContext context)
        {
            _context = context;
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }
 
 
        // GET: api/User/5
        [HttpGet("{FullName}")]
        public async Task<ActionResult<User>> GetUser(int FullName)
        {
            var User = await _context.Users.FindAsync(FullName);
 
            if (User == null)
            {
                return NotFound();
            }
 
            return User;
        }
 
        // PUT: api/User/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        [HttpPut("{FullName}")]
        public async Task<IActionResult> PutUser(string FullName, User User)
        {
            if (FullName != User.FullName)
            {
                return BadRequest();
            }
 
            _context.Entry(User).State = EntityState.Modified;
 
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(FullName))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
 
            return NoContent();
        }
 
        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
 
            return CreatedAtAction("GetUser", new { FullName = User.FullName }, User);
        }
 
        // DELETE: api/User/5
        [HttpDelete("{FullName}")]
        public async Task<ActionResult<User>> DeleteUser(string FullName)
        {
            var User = await _context.Users.FindAsync(FullName);
            if (User == null)
            {
                return NotFound();
            }
 
            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
 
            return User;
        }
 
        private bool UserExists(string FullName)
        {
            return _context.Users.Any(e => e.FullName == FullName);
        }
    }
}
