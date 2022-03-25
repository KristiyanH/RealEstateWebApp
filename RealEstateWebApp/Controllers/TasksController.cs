using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.Infrastructure;
using RealEstateWebApp.Services.Tasks;
using RealEstateWebApp.ViewModels.Tasks;
using System.Linq;

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

            return RedirectToAction("All", "Properties");

        }
    }
}
