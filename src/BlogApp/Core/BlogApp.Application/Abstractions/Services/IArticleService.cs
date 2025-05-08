using BlogApp.Domain.Entities;

namespace BlogApp.Application.Abstractions.Services
{
    public interface IArticleService
    {
        public Task<bool> CreateArticle(Article article);
        public Task DeleteArticle(string id);
        public Task UpdateArticle(string id, Article article);
        public Task<Article> GetArticleByID(string id);
        public List<Article> GetAll();
    }
}
