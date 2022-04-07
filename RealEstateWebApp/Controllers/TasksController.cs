using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Data;
using RealEstateWebApp.Infrastructure;
using RealEstateWebApp.Services.Tasks;
using RealEstateWebApp.ViewModels.Tasks;
using System;
using System.Linq;
using static RealEstateWebApp.ErrorConstants;
namespace RealEstateWebApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly RealEstateDbContext data;
        private readonly ITaskService taskService;

        public TasksController(
            RealEstateDbContext _data,
            ITaskService _taskService)
        {
            data = _data;
            taskService = _taskService;
        }

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

            return RedirectToAction("MyTasks", "Tasks");

        }

        [Authorize(Roles = "Manager,Employee")]
        public IActionResult MyTasks()
        {
            if (User.IsInRole("Manager"))
            {
                return View(data.Tasks);
            }

            return View(data.Tasks.Where(x => x.UserId == User.GetId()));
        }

        [Authorize(Roles = "Manager")]
        public IActionResult EditTask()
            => View();

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public IActionResult EditTask(EditTaskFormModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                taskService.EditTask(model);
                return RedirectToAction("MyTasks", "Tasks");
            }
            catch (ArgumentException aex)
            {
                ViewData["ErrorTitle"] = ErrorTitle;
                ViewData["ErrorMessage"] = aex.Message;

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

                return RedirectToAction("MyTasks", "Tasks");
            }
            catch (ArgumentException aex)
            {
                ViewData["ErrorTitle"] = ErrorTitle;
                ViewData["ErrorMessage"] = aex.Message;

                return View("Error");
            }
        }
    }
}
