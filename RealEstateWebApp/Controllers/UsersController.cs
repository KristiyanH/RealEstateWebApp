using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Services.Users;

namespace RealEstateWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        [Authorize(Roles = "Manager")]
        public IActionResult AllUsers()
        {
            return View(userService.AllUsers());
        }
    }
}
