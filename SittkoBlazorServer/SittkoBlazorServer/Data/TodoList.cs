using System.ComponentModel.DataAnnotations;

namespace SittkoBlazorServer.Data
{
    public class TodoList
    {

        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateOnly CreationDate { get; set; }
        public DateOnly? ExecutionDate { get; set; }
        public bool Completed { get; set; } = false;
    }
}
