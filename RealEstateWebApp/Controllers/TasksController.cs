using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Data;
using RealEstateWebApp.Services.Tasks;
using RealEstateWebApp.ViewModels.Tasks;

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

        [Authorize(Roles = "Administrator,Manager")]
        public IActionResult SetTask()
            => View();

        [HttpPost]
        [Authorize(Roles = "Administrator,Manager")]
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
