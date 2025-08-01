using BlogApp.Application.Abstractions.Repositories.Articles;
using BlogApp.Domain.Entities;
using BlogApp.Persistence.Contexts;

namespace BlogApp.Persistence.Concretes.Repositories.Articles
{
    public class ArticleWriteRepository : WriteRepository<Article>, IArticleWriteRepository
    {
        public ArticleWriteRepository(BlogAppDBContext blogAppDBContext) : base(blogAppDBContext)
        {
        }
    }
}
