using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAplikacija.Models;

namespace TestAplikacija.Services.TodoServices
{
    public class TodoServices : ITodoServices
    {
        public SQLiteAsyncConnection _database;
        string _dbPath;
        SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

        public TodoServices(string dbPath)
        {
            _dbPath = dbPath;
            InitAsync();
        }

        private async Task InitAsync()
        {
            if (_database != null)
            {
                return;
            }
            _database = new SQLiteAsyncConnection(_dbPath, Flags);
            await _database.CreateTableAsync<Todo>();
        }

        public async Task<bool> AddUpdateTodo(Todo todo)
        {
            if (todo.Id > 0)
            {
                await _database.UpdateAsync(todo);
            }
            else
            {
                await _database.InsertAsync(todo);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteTodo(int id)
        {
            await _database.DeleteAsync<Todo>(id);
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await Task.FromResult(await _database.Table<Todo>().ToListAsync());
        }

        public async Task<Todo> GetTodo(int id)
        {
            return await _database.Table<Todo>().Where(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}
