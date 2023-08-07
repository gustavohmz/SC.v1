using Microsoft.EntityFrameworkCore;
using SC.v1.Core.Interfaces;
using SC.v1.Data.Domain.Models;

namespace SC.v1.Data.Persistence.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly MyCompanyContext _context;

        public UserRepository(MyCompanyContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            return user;
        }
    }
}
