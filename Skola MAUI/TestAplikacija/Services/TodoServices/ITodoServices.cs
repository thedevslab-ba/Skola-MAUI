using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAplikacija.Models;

namespace TestAplikacija.Services.TodoServices
{
    public interface ITodoServices
    {
        Task<bool> AddUpdateTodo(Todo todo);
        Task<bool> DeleteTodo(int id);
        Task<Todo> GetTodo(int id);
        Task<IEnumerable<Todo>> GetAllTodos();
    }
}
