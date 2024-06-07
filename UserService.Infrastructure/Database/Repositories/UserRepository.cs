using Domain.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using UserService.Application.Interfaces.Database;

namespace UserService.Infrastructure.Database.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbContextFactory<UserServiceDbContext> factory) : base(factory)
        {
            _contextFactory = factory;
        }
    }
}
