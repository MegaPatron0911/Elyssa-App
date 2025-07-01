using Microsoft.AspNetCore.Authorization;

namespace ApiProject.Authorization;

/// <summary>
/// Atributo para proteger endpoints por permiso específico.
/// </summary>
public class AuthorizePermissionAttribute : AuthorizeAttribute
{
    public AuthorizePermissionAttribute(string permission) : base()
    {
        Policy = $"Permission:{permission}";
    }
}
