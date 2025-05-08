using BlogApp.Domain.Entities;

namespace BlogApp.Application.Abstractions.Services
{
    public interface IArticleService
    {
        public Task<bool> CreateArticleAsync(Article article);
        public Task<bool> RemoveArticleAsync(string id);
        public Task<bool> UpdateArticleAsync(string id, Article article);
        public Task<Article> GetArticleByID(string id);
        public List<Article> GetAll();
    }
}
