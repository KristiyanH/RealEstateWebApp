using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Services.Users;
using static RealEstateWebApp.WebConstants;

namespace RealEstateWebApp.Areas.Manager.Controllers
{
    [Area(ManagerRoleName)]
    [Authorize(Roles = ManagerRoleName)]
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        public IActionResult AllUsers()
        {
            return View(userService.AllUsers());
        }
    }
}
