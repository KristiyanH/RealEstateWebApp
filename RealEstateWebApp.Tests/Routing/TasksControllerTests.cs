using Xunit;
using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.ViewModels.Tasks;

namespace RealEstateWebApp.Tests.Routing
{
    public class TasksControllerTests
    {
        [Fact]
        public void SetTaskGetRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Tasks/SetTask")
            .To<TasksController>(c => c.SetTask());

        [Fact]
        public void SetTaskPostRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request
            .WithPath("/Tasks/SetTask")
            .WithMethod(HttpMethod.Post))
            .To<TasksController>(c => c.SetTask(With.Any<SetTaskFormModel>()));

        [Fact]
        public void MyTasksRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Tasks/MyTasks")
            .To<TasksController>(c => c.MyTasks());

        [Fact]
        public void EditTaskGetRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Tasks/EditTask")
            .To<TasksController>(c => c.EditTask());

        [Fact]
        public void EditTaskPostRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request
            .WithPath("/Tasks/EditTask")
            .WithMethod(HttpMethod.Post))
            .To<TasksController>(c => c.EditTask(With.Any<EditTaskFormModel>()));
    }
}
