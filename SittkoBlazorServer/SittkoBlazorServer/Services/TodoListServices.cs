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

        public async Task<TodoItem> TODOListByIdAsync(Guid tODOListId)
        {
            var tODOLiistById = await _db.TodoItems.FirstOrDefaultAsync(x => x.Id == tODOListId);
            return tODOLiistById ?? new TodoItem();
        }
        public async Task<List<TodoItem>> TODOListGetAllAsync() => await _db.TodoItems.ToListAsync();
        public List<TodoItem> TODOListGetAll() => _db.TodoItems.ToList();
        public async Task<bool> TODOListCreatedAsync(TodoItem tOdoItem)
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
        public async Task TODOListCreated(TodoItem tOdoItem)
        {
            await _db.TodoItems.AddAsync(tOdoItem);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> TODOListDeletedAsync(Guid tODOListId)
        {
            var tODOListDeletedById = await _db.TodoItems.FirstOrDefaultAsync(x => x.Id == tODOListId);
            if (tODOListDeletedById == null)
                return false;
            _db.TodoItems.Remove(tODOListDeletedById);
            await _db.SaveChangesAsync();
            return true;
        }



        public async Task<bool> TODOListUpdatedAsync(TodoItem tOdoItemId)
        {
            var enyIdTODOList = await _db.TodoItems.FirstOrDefaultAsync
                (x => x.Id == tOdoItemId.Id);
            if (enyIdTODOList == null)
                return false;
            _db.TodoItems.Update(enyIdTODOList);
            await _db.SaveChangesAsync();

            return true;
        }

        public Task<List<TodoItem>> TODOListActives()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TodoItem>> TODOListComplitedsAsync(bool completed)
        {
            return await _db.TodoItems.Where(x => x.Completed == completed).ToListAsync();
        }

        public List<TodoItem> TODOListCompliteds(bool completed)
        {
            return _db.TodoItems.Where(x => x.Completed == completed).ToList();
        }

        public TodoItem TODOListById(Guid tODOListId)
        {
            var tODOLiistById = _db.TodoItems.FirstOrDefault(x => x.Id == tODOListId);
            return tODOLiistById ?? new TodoItem();
        }

        public bool TODOListUpdated(TodoItem tOdoItemId)
        {
            var enyIdTODOList = _db.TodoItems.FirstOrDefault
    (x => x.Id == tOdoItemId.Id);
            if (enyIdTODOList == null)
                return false;
            _db.TodoItems.Update(enyIdTODOList);
            _db.SaveChanges();

            return true;
        }

        public bool TODOListDeleted(Guid tODOListId)
        {
            var tODOListDeletedById = _db.TodoItems.FirstOrDefault(x => x.Id == tODOListId);
            if (tODOListDeletedById == null)
                return false;
            _db.TodoItems.Remove(tODOListDeletedById);
            _db.SaveChanges();
            return true;
        }

        public bool TodoListsUpdated(List<TodoItem> todoLists)
        {
            _db.TodoItems.UpdateRange(todoLists);
            _db.SaveChanges();
            return true;
        }
    }
}
