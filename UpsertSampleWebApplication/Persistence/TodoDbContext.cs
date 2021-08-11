using Microsoft.EntityFrameworkCore;

namespace UpsertSampleWebApplication.Persistence
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoEntity> Todos { get; set; }
        
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        { }
    }
}