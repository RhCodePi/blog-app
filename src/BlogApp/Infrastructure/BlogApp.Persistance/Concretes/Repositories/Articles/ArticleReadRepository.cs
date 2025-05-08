using BlogApp.Application.Abstractions.Repositories.Articles;
using BlogApp.Domain.Entities;
using BlogApp.Persistance.Contexts;

namespace BlogApp.Persistance.Concretes.Repositories.Articles
{
    public class ArticleReadRepository : ReadRepository<Article>, IArticleReadRepository
    {
        public ArticleReadRepository(BlogAppDBContext blogAppDBContext) : base(blogAppDBContext)
        {
        }
    }
}
