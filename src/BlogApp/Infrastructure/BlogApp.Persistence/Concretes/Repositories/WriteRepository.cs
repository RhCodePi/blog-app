using BlogApp.Application.Abstractions.Repositories;
using BlogApp.Domain.Entities.Common;
using BlogApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlogApp.Persistence.Concretes.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly BlogAppDBContext _blogAppDBContext;


        public WriteRepository(BlogAppDBContext blogAppDBContext)
        {
            _blogAppDBContext = blogAppDBContext;
        }

        public DbSet<T> Table => _blogAppDBContext.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);

            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> model)
        {
            await Table.AddRangeAsync(model);

            return true;
        }

        public bool Remove(T model)
        {
            var result = _blogAppDBContext.Remove(model);

            return result.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T? model = await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));


            return model != null && Remove(model);
        }

        public bool Update(T model)
        {
            var result = Table.Update(model);

            return result.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync() => await _blogAppDBContext.SaveChangesAsync();
    }
}
