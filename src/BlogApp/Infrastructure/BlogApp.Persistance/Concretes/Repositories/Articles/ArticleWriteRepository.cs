using BlogApp.Application.Abstractions.Repositories.Articles;
using BlogApp.Domain.Entities;
using BlogApp.Persistance.Contexts;

namespace BlogApp.Persistance.Concretes.Repositories.Articles
{
    public class ArticleWriteRepository : WriteRepository<Article>, IArticleWriteRepository
    {
        public ArticleWriteRepository(BlogAppDBContext blogAppDBContext) : base(blogAppDBContext)
        {
        }
    }
}
