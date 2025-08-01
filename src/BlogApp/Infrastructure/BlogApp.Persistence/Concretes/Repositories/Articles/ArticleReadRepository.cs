using BlogApp.Application.Abstractions.Repositories.Articles;
using BlogApp.Domain.Entities;
using BlogApp.Persistence.Contexts;

namespace BlogApp.Persistence.Concretes.Repositories.Articles
{
    public class ArticleReadRepository : ReadRepository<Article>, IArticleReadRepository
    {
        public ArticleReadRepository(BlogAppDBContext blogAppDBContext) : base(blogAppDBContext)
        {
        }
    }
}
