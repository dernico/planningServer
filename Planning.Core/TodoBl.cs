using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Core.Interfaces;
using Planning.Core.Models;

namespace Planning.Core
{
    public class TodoBl : ITodoBl
    {
        private readonly ITodoRepository _todos;

        public TodoBl(ITodoRepository todos)
        {
            _todos = todos;
        }
        public List<TodoModel> ReadAll()
        {
            return _todos.ReadAll();
        }

        public void Add(TodoModel todoModel)
        {
            _todos.AddTodo(todoModel);
        }

        public void Delete(int id)
        {
            _todos.DeleteTodo(id);
        }

        public void Update(TodoModel model)
        {
            _todos.UpdateTodo(model);
        }

        public TodoModel Read(int id)
        {
            return _todos.Read(id);
        }
    }
}
