using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ChariTov;
using ChariTov.Models;
using Microsoft.EntityFrameworkCore;
using ChariTov.DataBaseContext;
using System.Diagnostics.Contracts;

public interface IUserService
{
    Task CreateUserAsync(User newUser);
    Task<User> GetUserByNameAsync(string userName);
    Task<User> GetUserByIdAsync(int id);
    Task<bool> RemoveUserByIdAsync(int id);

    bool VerifyPassword(string hashedPassword, string password);
}

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    private const string dbName = "dbName";

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserByNameAsync(string userName)
    {
        return await _context.Users?.SingleOrDefaultAsync(u => u.Name == userName);
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> RemoveUserByIdAsync(int id)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);
        _context.SaveChanges();

        return true;
    }



    public bool VerifyPassword(string hashedPassword, string password)
    {
        var hash = Utilities.HashPassword(password);
        return hash == hashedPassword;
    }
}
