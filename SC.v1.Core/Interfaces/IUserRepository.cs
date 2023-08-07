using SC.v1.Data.Domain.Models;

namespace SC.v1.Core.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetUserByUsername(string username);
    }
}
