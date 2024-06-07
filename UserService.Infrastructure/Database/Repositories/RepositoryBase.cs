using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserService.Application.Interfaces.Database;

namespace UserService.Infrastructure.Database.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected IDbContextFactory<UserServiceDbContext> _contextFactory;

        protected RepositoryBase(IDbContextFactory<UserServiceDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            var context = _contextFactory.CreateDbContext();
            return context.Set<T>().Where(expression);
        }

        public virtual async Task CreateAsync(T entity)
        {
            var context = _contextFactory.CreateDbContext();
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }
    }
}
