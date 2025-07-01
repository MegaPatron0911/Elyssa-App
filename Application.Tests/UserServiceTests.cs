using Domain.Models;
using Application.Services;
using Xunit;

namespace Application.Tests;

public class UserServiceTests
{
    [Fact]
    public void CreateUser_ShouldAddUser()
    {
        var service = new UserService();
        var user = service.CreateUser("test@mail.com", "Test User", "1234", Guid.NewGuid());
        Assert.NotNull(user);
        Assert.Equal("test@mail.com", user.Email);
    }

    [Fact]
    public void GetUserByEmail_ShouldReturnUser()
    {
        var service = new UserService();
        var user = service.CreateUser("test2@mail.com", "Test2", "pass", Guid.NewGuid());
        var found = service.GetUserByEmail("test2@mail.com");
        Assert.NotNull(found);
        Assert.Equal(user.Email, found!.Email);
    }
}
