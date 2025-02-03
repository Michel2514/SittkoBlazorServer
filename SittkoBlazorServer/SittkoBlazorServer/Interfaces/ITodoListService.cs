using SittkoBlazorServer.Data;

namespace SittkoBlazorServer.Interfaces
{
    public interface ITodoListService
    {
        Task<bool> TodoTaskCreateAsync(TodoItem todoItem);
        Task TodoTaskCreateVoidAsync(TodoItem todoItem);
        Task<bool> TodoTaskUpdateAsync(TodoItem todoItemId);
        Task<TodoItem> TodoItemByIdAsync(Guid todoListId);
        Task<bool> TodoItemByIdDeleteAsync(Guid todoListId);
        Task<List<TodoItem>> TodoListAllAsync();
    }
}