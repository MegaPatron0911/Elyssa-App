namespace ElyssaBack.Domain.Models;

// Represents a user in the system
public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    // Stores the hashed password for security
    public string PasswordHash { get; set; } = string.Empty;
    public Guid RoleId { get; set; }
    // Navigation property for the user's role
    public Role? Role { get; set; }
}

// Defines a role that can be assigned to users
public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    // List of permissions associated with this role
    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}

// Represents a specific permission in the system
public class Permission
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
