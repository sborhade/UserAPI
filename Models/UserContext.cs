using Microsoft.EntityFrameworkCore;

namespace UserAPI.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<User> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
