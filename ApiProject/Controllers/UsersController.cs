using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
// Controller for handling user-related HTTP requests
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    // Constructor with dependency injection of the user service
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // Creates a new user
    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] CreateUserRequest request)
    {
        var user = _userService.CreateUser(request.Email, request.Name, request.Password, request.RoleId);
        return Ok(user);
    }

    // Returns all users
    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        return Ok(_userService.GetAllUsers());
    }
}

// Request model for creating a user
public record CreateUserRequest(string Email, string Name, string Password, Guid RoleId);
