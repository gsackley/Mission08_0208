using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Quadrants()
        {
            var newTask = _taskContext.Tasks.Include(X => X.Category).ToList();
            return View(newTask);
        }

        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = _taskContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult TaskForm(Task_ hcm)
        {
            if (ModelState.IsValid)
            {
                _taskContext.Add(hcm);
                _taskContext.SaveChanges();

                return View("Confirmation", hcm);
            }
            else // If Invalid
            {
                ViewBag.Categories = _taskContext.Categories.ToList();
                return View(hcm);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _taskContext.Categories.ToList();

            var tasks = _taskContext.Tasks.Single(item => item.TaskId == id);
            return View("TaskForm", tasks);
        }

        [HttpPost]
        public IActionResult Edit(Task_ ar)
        {
            _taskContext.Update(ar);
            _taskContext.SaveChanges();


            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var tasks = _taskContext.Tasks.Single(item => item.TaskId == id);
            return View(tasks);
        }

        [HttpPost]
        public IActionResult Delete(Task_ ar)
        {
            _taskContext.Tasks.Remove(ar);
            _taskContext.SaveChanges();
            return RedirectToAction("Quadrants");

        }
    }
}
