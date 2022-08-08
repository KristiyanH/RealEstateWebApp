using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Tasks;
using System.Collections.Generic;
using Xunit;
using static RealEstateWebApp.Tests.Data.Tasks;
namespace RealEstateWebApp.Tests.Controllers
{
    public class TasksControllerTests
    {
        [Fact]
        public void SetTaskGetShouldBeForAuthorizedUsersAndReturnView()
            => MyController<TasksController>
            .Instance()
            .Calling(c => c.SetTask())
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .View();

        [Fact]
        public void SetTaskPostShouldBeForAuthorizedUsersAndShouldReturnRedirectToActionWithCorrectData()
            => MyController<TasksController>
            .Instance()
            .WithData(new User
            {
                Id = "3f165359-3f79-4fa0-aefb-c030ac5ebd87",
                Email = "kristiyan.a.hristov@gmail.com",
                PhoneNumber = "0876065511",
                FullName = "Kristiyan Hristov",
                UserName = "kristiyan.a.hristov@gmail.com"
            })
            .Calling(c => c.SetTask(new SetTaskFormModel
            {
                UserId = "3f165359-3f79-4fa0-aefb-c030ac5ebd87",
                Description = "Do something test"
            }))
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForHttpMethod(HttpMethod.Post)
            .RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .RedirectToAction("MyTasks");

        [Fact]
        public void MyTasksShouldBeForAuthorizedUsersAndReturnViewWithCorrectModel()
            => MyController<TasksController>
            .Instance()
            .WithUser()
            .WithData(TenTasks())
            .Calling(c => c.MyTasks())
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .View(v => v
            .WithModelOfType<IEnumerable<Task>>());

        [Fact]
        public void EditTaskGetShouldBeForAuthorizedUsersAndReturnView()
            => MyController<TasksController>
            .Instance()
            .Calling(c => c.EditTask())
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .View();

        [Fact]
        public void EditTaskPostShouldReturnViewWithCorrectModelIfModelStateIsInvalid()
            => MyController<TasksController>
            .Instance()
            .Calling(c => c.EditTask(new EditTaskFormModel()
            {
                TaskId = 1,
                Description = "a"
            }))
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForAuthorizedRequests()
            .RestrictingForHttpMethod(HttpMethod.Post))
            .AndAlso()
            .ShouldReturn()
            .View(v => v
            .WithModelOfType<EditTaskFormModel>());


        [Fact]
        public void EditTaskPostShouldReturnErrorViewWithIncorrectData()
            => MyController<TasksController>
            .Instance()
            .Calling(c => c.EditTask(new EditTaskFormModel()
            {
                TaskId = 1,
                Description = "Some random description"
            }))
            .ShouldReturn()
            .View("Error");

        [Fact]
        public void EditTaskPostShouldReturnRedirectToActionWithCorrectData()
            => MyController<TasksController>
            .Instance()
            .WithData(TenTasks())
            .Calling(c => c.EditTask(new EditTaskFormModel()
            {
                TaskId = 1,
                Description = "New valid description"
            }))
            .ShouldReturn()
            .RedirectToAction("MyTasks");
    }
}
