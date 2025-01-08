using SittkoBlazorServer.Data;

namespace SittkoBlazorServer.Interfaces
{
    public interface ITodoListService
    {
        Task<bool> TODOListCreatedAsync(TodoItem todoItem);
        Task TODOListCreated(TodoItem todoItem);

        public Task<bool> TODOListDeletedAsync(Guid todoListId);
        public Task<bool> TODOListUpdatedAsync(TodoItem todoItemId);
        public Task<TodoItem> TODOListByIdAsync(Guid todoListId);

        public Task<List<TodoItem>> TODOListGetAllAsync();
        public List<TodoItem> TODOListGetAll();

        public Task<List<TodoItem>> TODOListComplitedsAsync(bool completed);
        public Task<List<TodoItem>> TODOListActives();
        public List<TodoItem> TODOListCompliteds(bool completed);
        public TodoItem TODOListById(Guid todoListId);
        public bool TODOListUpdated(TodoItem todoItemId);
        public bool TODOListDeleted(Guid todoListId);
        public bool TodoListsUpdated(List<TodoItem> todoLists);
    }
}
