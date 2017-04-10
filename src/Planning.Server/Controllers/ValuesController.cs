using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planning.Server.Data;

namespace Planning.Server.Controllers
{

public class Todo{
    public int id {get;set;}
    public string title{get;set;}
    public string description {get;set;}
}


    [Route("api/[controller]")]
    [Authorize]
    public class ValuesController : Controller
    {
        private TodoContext _todoContext;
        public ValuesController(TodoContext todos)
        {
            _todoContext = todos;
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            //return _todoContext
            //    .Todos
            //    .Select(t => new Todo() { id = t.Id, title = t.Title, description = t.Description })
            //    .ToList();
            return new List<Todo> {
                 new Todo { id = 1, title = "todo 1", description = "description1" },
                 new Todo { id = 2, title = "todo 2", description = "description1" },
                 new Todo { id = 3, title = "todo 3", description = "description1" },
             };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Todo todo)
        {
            _todoContext.Todos.Add(new Model.Todo() { Title = todo.title, Description = todo.description } );
            _todoContext.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var todo = _todoContext.Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return;

            _todoContext.Todos.Remove(todo);
            _todoContext.SaveChanges();
        }
    }
}
