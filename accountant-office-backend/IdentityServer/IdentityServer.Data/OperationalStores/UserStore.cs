using IdentityServer.Data.DbContexts;
using IdentityServer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data.OperationalStores;

public class UserStore
{
    private readonly OperationalDataContext dbContext;
    public UserStore(OperationalDataContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async ValueTask<User?> GetUserById(Guid id)
    {
        return await dbContext.Users.FindAsync(id);
    }

    public async ValueTask<User?> GetUserByUsernameAsync(string email)
    {
        return await dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
    }

    public async ValueTask<User> CreateUser(User user)
    {
        var newUser = await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();

        return newUser.Entity;
    }
}