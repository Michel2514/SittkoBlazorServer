using System.ComponentModel.DataAnnotations;

namespace SittkoBlazorServer.Data
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        [Required] public string Name { get; set; }

        [Required] public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExecutionDate { get; set; }
        public bool Completed { get; set; }
    }
}