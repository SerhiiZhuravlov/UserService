using System.Linq.Expressions;

namespace UserService.Application.Interfaces.Database
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
    }
}
