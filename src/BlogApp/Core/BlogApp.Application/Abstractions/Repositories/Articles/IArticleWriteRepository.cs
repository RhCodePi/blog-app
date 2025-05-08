using BlogApp.Domain.Entities;

namespace BlogApp.Application.Abstractions.Repositories.Articles
{
    public interface IArticleWriteRepository: IWriteRepository<Article>
    {
    }
}
