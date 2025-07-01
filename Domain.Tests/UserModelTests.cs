using Domain.Models;
using Xunit;

namespace Domain.Tests;

public class UserModelTests
{
    [Fact]
    public void User_ShouldHaveRole()
    {
        var role = new Role { Id = Guid.NewGuid(), Name = "Admin" };
        var user = new User { Id = Guid.NewGuid(), Email = "a@b.com", Name = "A", PasswordHash = "x", RoleId = role.Id, Role = role };
        Assert.Equal(role.Id, user.RoleId);
        Assert.Equal("Admin", user.Role!.Name);
    }
}
