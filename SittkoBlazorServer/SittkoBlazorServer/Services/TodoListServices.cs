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

        public async Task<TodoList> TODOListByIdAsync(Guid tODOListId)
        {
            var tODOLiistById = await _db.TODOLists.FirstOrDefaultAsync(x => x.Id == tODOListId);
            return tODOLiistById ?? new TodoList();
        }
        public async Task<List<TodoList>> TODOListGetAllAsync() => await _db.TODOLists.ToListAsync();
        public List<TodoList> TODOListGetAll() => _db.TODOLists.ToList();
        public async Task<bool> TODOListCreatedAsync(TodoList tODOList)
        {
            try
            {

                await _db.TODOLists.AddAsync(tODOList);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool TODOListCreated(TodoList tODOList)
        {
            _db.TODOLists.Add(tODOList);
            _db.SaveChanges();
            return true;
        }

        public async Task<bool> TODOListDeletedAsync(Guid tODOListId)
        {
            var tODOListDeletedById = await _db.TODOLists.FirstOrDefaultAsync(x => x.Id == tODOListId);
            if (tODOListDeletedById == null)
                return false;
            _db.TODOLists.Remove(tODOListDeletedById);
            await _db.SaveChangesAsync();
            return true;
        }



        public async Task<bool> TODOListUpdatedAsync(TodoList tODOListId)
        {
            var enyIdTODOList = await _db.TODOLists.FirstOrDefaultAsync
                (x => x.Id == tODOListId.Id);
            if (enyIdTODOList == null)
                return false;
            _db.TODOLists.Update(enyIdTODOList);
            await _db.SaveChangesAsync();

            return true;
        }

        public Task<List<TodoList>> TODOListActives()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TodoList>> TODOListComplitedsAsync(bool completed)
        {
            return await _db.TODOLists.Where(x => x.Completed == completed).ToListAsync();
        }

        public List<TodoList> TODOListCompliteds(bool completed)
        {
            return _db.TODOLists.Where(x => x.Completed == completed).ToList();
        }

        public TodoList TODOListById(Guid tODOListId)
        {
            var tODOLiistById = _db.TODOLists.FirstOrDefault(x => x.Id == tODOListId);
            return tODOLiistById ?? new TodoList();
        }

        public bool TODOListUpdated(TodoList tODOListId)
        {
            var enyIdTODOList = _db.TODOLists.FirstOrDefault
    (x => x.Id == tODOListId.Id);
            if (enyIdTODOList == null)
                return false;
            _db.TODOLists.Update(enyIdTODOList);
            _db.SaveChanges();

            return true;
        }

        public bool TODOListDeleted(Guid tODOListId)
        {
            var tODOListDeletedById = _db.TODOLists.FirstOrDefault(x => x.Id == tODOListId);
            if (tODOListDeletedById == null)
                return false;
            _db.TODOLists.Remove(tODOListDeletedById);
            _db.SaveChanges();
            return true;
        }

        public bool TodoListsUpdated(List<TodoList> todoLists)
        {
            _db.TODOLists.UpdateRange(todoLists);
            _db.SaveChanges();
            return true;
        }
    }
}
