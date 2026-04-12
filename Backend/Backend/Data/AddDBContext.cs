using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AddDBContext:DbContext
    {
        public AddDBContext(DbContextOptions<AddDBContext> options) : base(options) { }
        public DbSet<Roles> Roles => Set<Roles>();
        public DbSet<Users> Users => Set<Users>();

    }
}
