using Microsoft.EntityFrameworkCore;
using Planning.Server.Model;

namespace Planning.Server.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
