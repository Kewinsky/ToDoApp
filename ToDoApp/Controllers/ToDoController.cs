using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        private static IList<ToDoModel> tasks = new List<ToDoModel>() 
        { 
            new ToDoModel(){ TaskId = 1, Name = "Wynieść śmieci", Description = "Po śniadaniu", Done = false},
            new ToDoModel(){ TaskId = 2, Name = "Posprzątać pokój", Description = "Jak najszybciej", Done = false}
        };


        // GET: ToDo
        public ActionResult Index()
        {
            return View(tasks.Where(x => !x.Done));
        }

        // GET: ToDo/Details/5
        public ActionResult Details(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id)); 
        }

        // GET: ToDo/Create
        public ActionResult Create()
        {
            return View(new ToDoModel());
        }

        // POST: ToDo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoModel todomodel)
        {
            todomodel.TaskId = tasks.Count + 1;
            tasks.Add(todomodel);

            return RedirectToAction(nameof(Index));
            
        }

        // GET: ToDo/Edit/5
        public ActionResult Edit(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToDoModel todomodel)
        {
            ToDoModel todo = tasks.FirstOrDefault(x => x.TaskId == id);
            todo.Name = todomodel.Name;
            todo.Description = todomodel.Description;

            return RedirectToAction(nameof(Index));
        }

        // GET: ToDo/Delete/5
        public ActionResult Delete(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // POST: ToDo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ToDoModel todomodel)
        {
            ToDoModel todo = tasks.FirstOrDefault(x => x.TaskId == id);
            tasks.Remove(todo);

            return RedirectToAction(nameof(Index));
        }

        // GET: ToDo/Done
        public ActionResult Done(int id)
        {
            ToDoModel todo = tasks.FirstOrDefault(x => x.TaskId == id);
            todo.Done = true;

            return RedirectToAction(nameof(Index));
        }
    }
}
