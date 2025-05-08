using BlogApp.Domain.Entities.Common;

namespace BlogApp.Application.Abstractions.Repositories
{
    public interface IWriteRepository<T>: IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);
        bool Remove(T model);
        Task<bool> RemoveAsync(string id);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
