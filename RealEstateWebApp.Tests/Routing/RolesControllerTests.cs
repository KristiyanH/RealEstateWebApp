using Xunit;
using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Areas.Manager.Controllers;
using RealEstateWebApp.Areas.Manager.Models.Roles;
using System.Collections.Generic;

namespace RealEstateWebApp.Tests.Routing
{
    public class RolesControllerTests
    {
        [Fact]
        public void CreateRoleGetRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Manager/Roles/CreateRole")
            .To<RolesController>(c => c.CreateRole());

        [Fact]
        public void CreateRolePostRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request
            .WithPath("/Manager/Roles/CreateRole")
            .WithMethod(HttpMethod.Post))
            .To<RolesController>(c => c.CreateRole(With.Any<CreateRoleViewModel>()));

        [Fact]
        public void AllRolesRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Manager/Roles/AllRoles")
            .To<RolesController>(c => c.AllRoles());

        [Fact]
        public void EditRoleGetRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Manager/Roles/EditRole")
            .To<RolesController>(c => c.EditRole(With.Any<string>()));

        [Fact]
        public void EditRolePostRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request
            .WithPath("/Manager/Roles/EditRole")
            .WithMethod(HttpMethod.Post))
            .To<RolesController>(c => c.EditRole(With.Any<EditRoleViewModel>()));

        [Fact]
        public void EditUsersInRoleGetRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Manager/Roles/EditUsersInRole")
            .To<RolesController>(c => c.EditUsersInRole(With.Any<string>()));

        [Fact]
        public void EditUsersInRolePostRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request
            .WithPath("/Manager/Roles/EditUsersInRole")
            .WithMethod(HttpMethod.Post))
            .To<RolesController>(c => c.EditUsersInRole(With.Any<List<UserRoleViewModel>>(), With.Any<string>()));
    }
}
