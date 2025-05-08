using BlogApp.Application.Abstractions.Repositories;
using BlogApp.Domain.Entities.Common;
using BlogApp.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogApp.Persistance.Concretes.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly BlogAppDBContext _blogAppDBContext;

        public ReadRepository(BlogAppDBContext blogAppDBContext)
        {
            _blogAppDBContext = blogAppDBContext;
        }

        public DbSet<T> Table => _blogAppDBContext.Set<T>();


        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public async Task<T> GetByIdAsync(string id) => await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            return await Table.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            return Table.Where(method);
        }
    }
}
