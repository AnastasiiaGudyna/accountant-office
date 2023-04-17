using IdentityServer.Data.Models;
using IdentityServer.Data.OperationalStores;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Api.Services;

public class UserService
{
    private readonly UserStore store;
    private readonly IPasswordHasher<User> hasher;

    public UserService(UserStore store, IPasswordHasher<User> hasher)
    {
        this.store = store;
        this.hasher = hasher;
    }

    /// <summary>
    /// Validates the credentials.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="password">The password.</param>
    /// <returns></returns>
    public async ValueTask<bool> ValidateCredentials(string email, string password)
    {
        var user = await FindByUsernameAsync(email);
        if (user is null)
        {
            // ToDo: Return correct result instead of 'bool'
            return false;
        }
        var result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);
        // ToDo: Return correct result instead of 'bool'
        return result == PasswordVerificationResult.Success;
    }

    /// <summary>
    /// Finds the user by username.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <returns></returns>
    public ValueTask<User?> FindByUsernameAsync(string email)
    {
        return store.GetUserByUsernameAsync(email);
    }

    /// <summary>
    /// Creates new user
    /// </summary>
    /// <param name="user">New user</param>
    /// <returns></returns>
    public async ValueTask<User> CreateUserAsync(User user)
    {
        user.PasswordHash = hasher.HashPassword(user, user.PasswordHash);
        user.CreateDate = DateTime.UtcNow;
        return await store.CreateUser(user);
    }
}