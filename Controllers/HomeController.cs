using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission08_0208.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_0208.Controllers
{
    public class HomeController : Controller
    {

        private TaskContext _taskContext { get; set; }

        public HomeController(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Quadrants()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int TaskId)
        {
            ViewBag.Categories = _taskContext.Categories.ToList();

            var tasks = _taskContext.Tasks.Single(item => item.TaskId == TaskId);
            return View("TaskForm", tasks);
        }

        [HttpPost]
        public IActionResult Edit(Models.Task ar)
        {
            _taskContext.Update(ar);
            _taskContext.SaveChanges();


            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int TaskId)
        {
            var tasks = _taskContext.Tasks.Single(item => item.TaskId == TaskId);
            return View(tasks);
        }

        [HttpPost]
        public IActionResult Delete(Models.Task ar)
        {
            _taskContext.Tasks.Remove(ar);
            _taskContext.SaveChanges();
            return RedirectToAction("Quadrants");

        }
    }
}
