using BlogApp.Domain.Entities.Common;
using System.Linq.Expressions;

namespace BlogApp.Application.Abstractions.Repositories
{
    public interface IReadRepository<T>: IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(string id);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
    }
}
