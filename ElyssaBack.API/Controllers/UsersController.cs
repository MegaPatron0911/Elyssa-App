using ElyssaBack.Application.Services;
using ElyssaBack.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElyssaBack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] CreateUserRequest request)
    {
        var user = _userService.CreateUser(request.Email, request.Name, request.Password, request.RoleId);
        return Ok(user);
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        return Ok(_userService.GetAllUsers());
    }
}

public record CreateUserRequest(string Email, string Name, string Password, Guid RoleId);
