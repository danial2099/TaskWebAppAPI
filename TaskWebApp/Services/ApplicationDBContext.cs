using API.Models;
using Microsoft.EntityFrameworkCore;
using TaskWebApp.Models;

namespace TaskWebApp.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users>User {  get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
