using System.Collections.Generic;
using System.Linq;
using Planning.Core.Interfaces;
using Planning.Core.Models;

namespace Planning.Data
{
    public class TodoRepository : ITodoRepository
    {
        private static readonly List<TodoModel> TodoList = new List<TodoModel>
        {
            new TodoModel
            {
                Id = 1,
                Description = "Todo Eintrag",
                Done = false,
                Title = "Todo Titel"
            },
            new TodoModel
            {
                Id = 5,
                Description = "Todo Eintrag 5",
                Done = false,
                Title = "Todo Titel 5"
            }
        };

        public List<TodoModel> ReadAll()
        {
            return TodoList;
        }

        public void AddTodo(TodoModel todo)
        {
            var newId = TodoList.Max(t => t.Id);
            todo.Id = newId + 1;

            TodoList.Add(todo);
        }

        public void UpdateTodo(TodoModel todo)
        {
            var toUpdate = TodoList.First(t => t.Id == todo.Id);
            toUpdate.Title = todo.Title;
            toUpdate.Description = todo.Description;
            toUpdate.Done = todo.Done;
        }

        public void DeleteTodo(int id)
        {
            TodoList.Remove(TodoList.First(t => t.Id == id));
        }

        public TodoModel Read(int id)
        {
            return TodoList.First(t => t.Id == id);
        }
    }
}
