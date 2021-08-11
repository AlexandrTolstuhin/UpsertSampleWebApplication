using Microsoft.EntityFrameworkCore;

namespace UpsertSampleWebApplication.Persistence
{
    public class TodoDbContextFactory : IDbContextFactory<TodoDbContext>
    {
        public TodoDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<TodoDbContext> builder = new();
            builder.UseInMemoryDatabase("INMEMORY");
            return new(builder.Options);
        }
    }
}