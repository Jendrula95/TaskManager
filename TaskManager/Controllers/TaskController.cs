using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManager.Models;
using System.Linq;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private static IList<TaskModel> tasks = new List<TaskModel>()
        {
            new TaskModel() {TaskId = 1 , Name = "Wizyta u mechanika", Description = "Godzina 10:00", Done = false},
             new TaskModel() {TaskId = 2 , Name = "Zrobić zadanie", Description = "Matematyka ", Done = false}
        };

        // GET: Task
        public ActionResult Index()
        {
            return View(tasks.Where(x => !x.Done));
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            taskModel.TaskId = tasks.Count + 1;
            tasks.Add(taskModel);
            return RedirectToAction(nameof(Index));

        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            task.Name = taskModel.Name;
            task.Description = taskModel.Description;
            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            tasks.Remove(task);
            return RedirectToAction(nameof(Index));
        }
        // GET: Task/Done
        public ActionResult Done(int id)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            task.Done = true;
            return RedirectToAction(nameof(Index));
        }
    }
}
