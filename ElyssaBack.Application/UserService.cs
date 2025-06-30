using ElyssaBack.Domain.Models;

namespace ElyssaBack.Application.Services;

public interface IUserService
{
    User CreateUser(string email, string name, string password, Guid roleId);
    User? GetUserByEmail(string email);
    IEnumerable<User> GetAllUsers();
}

public class UserService : IUserService
{
    private readonly List<User> _users = new();
    public User CreateUser(string email, string name, string password, Guid roleId)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            Name = name,
            PasswordHash = password, // Aquí luego se debe hashear
            RoleId = roleId
        };
        _users.Add(user);
        return user;
    }
    public User? GetUserByEmail(string email) => _users.FirstOrDefault(u => u.Email == email);
    public IEnumerable<User> GetAllUsers() => _users;
}
