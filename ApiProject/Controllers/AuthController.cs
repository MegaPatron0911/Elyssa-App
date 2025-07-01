using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AuthController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    /// <summary>
    /// Authenticates a user and returns a JWT if credentials are valid.
    /// </summary>
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = _userService.GetUserByEmail(request.Email);
        if (user == null || user.PasswordHash != request.Password) // TODO: Use hashed password comparison
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }

        var token = GenerateJwtToken(user);
        return Ok(new { token });
    }

    private string GenerateJwtToken(User user)
    {
        // Obtener permisos del usuario (por su rol)
        var permissions = user.Role?.Permissions?.Select(p => p.Name).ToList() ?? new List<string>();

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("role", user.RoleId.ToString())
        };
        // Agregar los permisos como claims individuales
        foreach (var perm in permissions)
        {
            claims.Add(new Claim("permission", perm));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /// <summary>
    /// Gets the profile of the authenticated user.
    /// </summary>
    [HttpGet("me")]
    [Authorize]
    public ActionResult<User> GetProfile()
    {
        var email = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email)?.Value;
        if (email == null)
            return Unauthorized();
        var user = _userService.GetUserByEmail(email);
        if (user == null)
            return NotFound();
        return Ok(user);
    }
}

public record LoginRequest(string Email, string Password);
