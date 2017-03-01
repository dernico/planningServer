using System.Collections.Generic;
using Planning.Core.Models;

namespace Planning.Core.Interfaces
{
    public interface ITodoRepository
    {
        List<TodoModel> ReadAll();
        void AddTodo(TodoModel todo);
        void UpdateTodo(TodoModel todo);
        void DeleteTodo(int id);
        TodoModel Read(int id);
    }
}