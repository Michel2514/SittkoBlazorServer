using SittkoBlazorServer.Data;

namespace SittkoBlazorServer.Interfaces
{
    public interface ITodoListService
    {
        public Task<bool> TODOListCreatedAsync(TodoList todoList);
        public bool TODOListCreated(TodoList todoList);

        public Task<bool> TODOListDeletedAsync(Guid todoListId);
        public Task<bool> TODOListUpdatedAsync(TodoList todoListId);
        public Task<TodoList> TODOListByIdAsync(Guid todoListId);

        public Task<List<TodoList>> TODOListGetAllAsync();
        public List<TodoList> TODOListGetAll();

        public Task<List<TodoList>> TODOListComplitedsAsync(bool completed);
        public Task<List<TodoList>> TODOListActives();
        public List<TodoList> TODOListCompliteds(bool completed);
        public TodoList TODOListById(Guid todoListId);
        public bool TODOListUpdated(TodoList todoListId);
        public bool TODOListDeleted(Guid todoListId);
        public bool TodoListsUpdated(List<TodoList> todoLists);
    }
}
