using Microsoft.EntityFrameworkCore;

namespace SittkoBlazorServer.Data
{
    public class TestDbContext : DbContext
    {
        public DbSet<TodoList> TODOLists { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
        { }
    }
}
