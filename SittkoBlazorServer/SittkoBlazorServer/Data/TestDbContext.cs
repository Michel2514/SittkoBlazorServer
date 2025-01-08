using Microsoft.EntityFrameworkCore;

namespace SittkoBlazorServer.Data
{
    public class TestDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
        { }
    }
}
