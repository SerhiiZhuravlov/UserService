using Domain.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int id);
        Task<User> CreateUserAsync(User user);
    }
}
