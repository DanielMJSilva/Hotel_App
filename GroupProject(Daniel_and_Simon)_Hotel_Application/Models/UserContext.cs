using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupProject_Daniel_and_Simon__Hotel_Application.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options){ }

        public DbSet<User> Users { get; set; }
    }
}
