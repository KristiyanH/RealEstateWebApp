using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Areas.Manager.Controllers;
using RealEstateWebApp.Areas.Manager.Models.Roles;
using static RealEstateWebApp.Tests.Data.Roles;
using Xunit;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using static RealEstateWebApp.Tests.Data.Users;
namespace RealEstateWebApp.Tests.Controllers
{
    public class RolesControllerTests
    {
        [Fact]
        public void RolesControllerShouldBeOnlyForAuthorized()
            => MyController<RolesController>
            .Instance()
            .ShouldHave()
            .Attributes(attributes => attributes
            .RestrictingForAuthorizedRequests());

        [Fact]
        public void CreateRoleGetShouldReturnView()
            => MyController<RolesController>
            .Instance()
            .Calling(c => c.CreateRole())
            .ShouldReturn()
            .View();

        [Fact]
        public void CreateRolePostShouldReturnViewWithCorrectModelIfInvalidModelState()
            => MyController<RolesController>
            .Instance()
            .Calling(c => c.CreateRole(new CreateRoleViewModel()
            {
                RoleName = "a"
            }))
            .ShouldReturn()
            .View(v => v
            .WithModelOfType<CreateRoleViewModel>());

        [Fact]
        public void CreateRolePostShouldReturnRedirectToActionIfDataIsCorrect()
            => MyController<RolesController>
            .Instance()
            .Calling(c => c.CreateRole(new CreateRoleViewModel()
            {
                RoleName = "Admin"
            }))
            .ShouldReturn()
            .RedirectToAction("AllRoles", "Roles");

        [Fact]
        public void AllRolesShouldReturnViewWithCorrectModel()
            => MyController<RolesController>
            .Instance()
            .WithData(TenRoles())
            .Calling(c => c.AllRoles())
            .ShouldReturn()
            .View(v => v
            .WithModelOfType<IEnumerable<IdentityRole>>());

        [Fact]
        public void EditRoleGetShouldReturnViewWithCorrectModel()
            => MyController<RolesController>
            .Instance()
            .WithData(Role())
            .Calling(c => c.EditRole("c6b71150-24ae-47d8-9a7c-da9fbfbbb386"))
            .ShouldReturn()
            .View(v => v
            .WithModelOfType<EditRoleViewModel>());

        [Fact]
        public void EditRoleGetShouldReturnErrorViewWithIncorrectData()
            => MyController<RolesController>
            .Instance()
            .Calling(c => c.EditRole(With.Any<string>()))
            .ShouldReturn()
            .View("Error");

        [Fact]
        public void EditRolePostShouldReturnViewWithCorrectModelIfModelStateIsInvalid()
            => MyController<RolesController>
            .Instance()
            .WithData(Role())
            .Calling(c => c.EditRole(new EditRoleViewModel()
            {
                Id = "c6b71150 - 24ae - 47d8 - 9a7c - da9fbfbbb386",
                RoleName = null
            }))
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForHttpMethod(HttpMethod.Post))
            .AndAlso()
            .ShouldReturn()
            .View(v => v
            .WithModelOfType<EditRoleViewModel>());

        [Fact]
        public void EditRolePostShouldReturnRedirectToActionWithCorrectData()
            => MyController<RolesController>
            .Instance()
            .WithData(Role())
            .Calling(c => c.EditRole(new EditRoleViewModel()
            {
                Id = "c6b71150-24ae-47d8-9a7c-da9fbfbbb386",
                RoleName = "Editted Name"
            }))
            .ShouldReturn()
            .RedirectToAction("AllRoles", "Roles");

        [Fact]
        public void EditUsersInRoleGetShouldReturnViewWithCorrectModel()
            => MyController<RolesController>
            .Instance()
            .WithData(Role())
            .AndAlso()
            .WithData(TenUsers())
            .Calling(c => c.EditUsersInRole("c6b71150-24ae-47d8-9a7c-da9fbfbbb386"))
            .ShouldReturn()
            .View(v => v
            .WithModelOfType<List<UserRoleViewModel>>());

        [Fact]
        public void EditUsersInRoleGetShouldReturnErrorViewWithIncorrectData()
            => MyController<RolesController>
            .Instance()
            .Calling(c => c.EditUsersInRole(With.Any<string>()))
            .ShouldReturn()
            .View("Error");

        [Fact]
        public void EditUsersInRolePostShouldReturnRedirectToActionWithInvalidData()
            => MyController<RolesController>
            .Instance()
            .WithData(Role())
            .Calling(c => c.EditUsersInRole(new List<UserRoleViewModel>(), "c6b71150-24ae-47d8-9a7c-da9fbfbbb386"))
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForHttpMethod(HttpMethod.Post))
            .AndAlso()
            .ShouldReturn()
            .RedirectToAction("EditRole", new { Id = "c6b71150-24ae-47d8-9a7c-da9fbfbbb386" });

        [Fact]
        public void DeleteRoleShouldReturnRedirectToActionWithCorrectData()
            => MyController<RolesController>
            .Instance()
            .WithData(Role())
            .Calling(c => c.DeleteRole("c6b71150-24ae-47d8-9a7c-da9fbfbbb386"))
            .ShouldReturn()
            .RedirectToAction("AllRoles", "Roles");

        [Fact]
        public void DeleteRoleShouldReturnErrorViewWithInvalidData()
            => MyController<RolesController>
            .Instance()
            .Calling(c => c.DeleteRole("invalidId"))
            .ShouldReturn()
            .View("Error");

    }
}
