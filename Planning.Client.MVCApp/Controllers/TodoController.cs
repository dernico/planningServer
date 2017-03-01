using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planning.Client.MVCApp.Views.Todo;
using Planning.Core;
using Planning.Core.Interfaces;
using Planning.Core.Models;

namespace Planning.Client.MVCApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoBl _todos;

        public TodoController(ITodoBl todos)
        {
            _todos = todos;
        }


        // GET: Todo
        public ActionResult Index()
        {
            var vm = new IndexModel();
            vm.Todos = _todos.ReadAll();

            return View(vm);
        }
        
        // POST: Todo/Create
        [HttpPost]
        public ActionResult Create(TodoModel todoModel)
        {
            try
            {
                _todos.Add(todoModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Edit/5
        public ActionResult Details(int id)
        {
            var model = _todos.Read(id);
            return View(new DetailsModel
            {
                Description = model.Description,
                Done = model.Done,
                Id = model.Id,
                Title = model.Title
            });
        }

        // POST: Todo/Edit/5
        [HttpPost]
        public ActionResult Details(TodoModel model)
        {
            try
            {
                _todos.Update(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _todos.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
