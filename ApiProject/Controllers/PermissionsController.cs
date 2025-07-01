using ApiProject.Authorization;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionsController : ControllerBase
{
    [HttpGet]
    [AuthorizePermission("VerPermisos")]
    public IActionResult GetPermissions()
    {
        return Ok(new[] { "Permiso1", "Permiso2" });
    }
}
