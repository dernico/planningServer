using System.Collections.Generic;
using Planning.Core.Models;

namespace Planning.Core.Interfaces
{
    public interface ITodoBl
    {
        List<TodoModel> ReadAll();
        TodoModel Read(int id);

        void Add(TodoModel todoModel);
        void Delete(int id);
        void Update(TodoModel model);
    }
}