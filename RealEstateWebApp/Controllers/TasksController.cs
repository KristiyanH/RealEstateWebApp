using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Infrastructure;
using RealEstateWebApp.Services.Tasks;
using RealEstateWebApp.ViewModels.Tasks;
using System;
using static RealEstateWebApp.ErrorConstants;

namespace RealEstateWebApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService _taskService)
            => taskService = _taskService;

        [Authorize(Roles = "Manager")]
        public IActionResult SetTask()
            => View();

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult SetTask(SetTaskFormModel task)
        {
            if (!ModelState.IsValid)
            {
                return View(task);
            }

            taskService.SetTask(task);

            return RedirectToAction(nameof(MyTasks));

        }

        [Authorize(Roles = "Manager,Employee")]
        public IActionResult MyTasks()
        {
            if (User.IsInRole("Manager"))
            {
                return View(taskService.GetAllTasks());
            }

            return View(taskService.GetAllTasksForUser(User.GetId()));
        }

        [Authorize(Roles = "Manager")]
        public IActionResult EditTask()
            => View();

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public IActionResult EditTask(EditTaskFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                taskService.EditTask(model);
                return RedirectToAction(nameof(MyTasks));
            }
            catch (ArgumentNullException anex)
            {
                ViewData["ErrorTitle"] = ErrorTitle;
                ViewData["ErrorMessage"] = anex.Message;

                return View("Error");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Manager, Employee")]
        public IActionResult CompleteTask(int taskId)
        {
            try
            {
                taskService.CompleteTask(taskId, User.GetId());

                return RedirectToAction(nameof(MyTasks));
            }
            catch (ArgumentNullException anex)
            {
                ViewData["ErrorTitle"] = ErrorTitle;
                ViewData["ErrorMessage"] = anex.Message;

                return View("Error");
            }
        }
    }
}
