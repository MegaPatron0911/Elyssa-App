using ElyssaBack.Domain.Models;

namespace ElyssaBack.Application.Services;

// Service interface for user-related operations
public interface IUserService
{
    // Creates a new user with the given data
    User CreateUser(string email, string name, string password, Guid roleId);
    // Retrieves a user by their email address
    User? GetUserByEmail(string email);
    // Returns all users in the system
    IEnumerable<User> GetAllUsers();
}

// In-memory implementation of the user service
public class UserService : IUserService
{
    // Internal list to store users (for demo purposes)
    private readonly List<User> _users = new();

    public User CreateUser(string email, string name, string password, Guid roleId)
    {
        // Note: Password should be hashed before storing in production
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            Name = name,
            PasswordHash = password, // TODO: Hash password before saving
            RoleId = roleId
        };
        _users.Add(user);
        return user;
    }

    public User? GetUserByEmail(string email) => _users.FirstOrDefault(u => u.Email == email);

    public IEnumerable<User> GetAllUsers() => _users;
}
