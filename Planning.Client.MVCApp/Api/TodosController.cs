using System.Collections.Generic;
using System.Web.Http;
using Planning.Core.Interfaces;
using Planning.Core.Models;

namespace Planning.Client.MVCApp.Api
{
    public class TodosController : ApiController
    {
        private readonly ITodoBl _todos;
        
        public TodosController(ITodoBl todos)
        {
            _todos = todos;
        }

        // GET: api/Todo
        public IEnumerable<TodoModel> Get()
        {
            return _todos.ReadAll();
        }

        // GET: api/Todo/5
        public TodoModel Get(int id)
        {
            return _todos.Read(id);
        }

        // POST: api/Todo
        public void Post([FromBody]TodoModel value)
        {
            _todos.Add(value);
        }

        // PUT: api/Todo/5
        public void Put(int id, [FromBody]TodoModel value)
        {
        }

        // DELETE: api/Todo/5
        public void Delete(int id)
        {
            _todos.Delete(id);
        }
    }
}
