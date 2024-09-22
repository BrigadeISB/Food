using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task AddAsync(User? user)
        {
            ArgumentNullException.ThrowIfNull(user);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            ArgumentNullException.ThrowIfNull(email);
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
    }
}
