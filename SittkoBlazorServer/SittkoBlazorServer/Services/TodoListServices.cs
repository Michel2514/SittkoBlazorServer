using Microsoft.EntityFrameworkCore;
using SittkoBlazorServer.Data;
using SittkoBlazorServer.Interfaces;

namespace SittkoBlazorServer.Services
{
    public class TodoListServices : ITodoListService
    {
        private readonly TestDbContext _db;

        public TodoListServices(TestDbContext db)
        {
            _db = db;
        }

        public async Task<TodoItem> TodoItemByIdAsync(Guid tODOListId)
        {
            var tODOLiistById = await _db.TodoItems.FirstOrDefaultAsync(x => x.Id == tODOListId);
            return tODOLiistById ?? new TodoItem();
        }

        public async Task<List<TodoItem>> TodoListAllAsync() => await _db.TodoItems.ToListAsync();

        public async Task<bool> TodoTaskCreateAsync(TodoItem tOdoItem)
        {
            try
            {
                await _db.TodoItems.AddAsync(tOdoItem);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task TodoTaskCreateVoidAsync(TodoItem tOdoItem)
        {
            await _db.TodoItems.AddAsync(tOdoItem);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> TodoItemByIdDeleteAsync(Guid tODOListId)
        {
            var tODOListDeletedById = await _db.TodoItems.FirstOrDefaultAsync(x => x.Id == tODOListId);
            if (tODOListDeletedById == null)
                return false;
            _db.TodoItems.Remove(tODOListDeletedById);
            await _db.SaveChangesAsync();
            return true;
        }


        public async Task<bool> TodoTaskUpdateAsync(TodoItem tOdoItemId)
        {
            var enyIdTODOList = await _db.TodoItems.FirstOrDefaultAsync
                (x => x.Id == tOdoItemId.Id);
            if (enyIdTODOList == null)
                return false;
            _db.TodoItems.Update(enyIdTODOList);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}