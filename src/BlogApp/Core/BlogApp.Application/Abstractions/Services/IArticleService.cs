using BlogApp.Application.DTOs.Article;
using BlogApp.Application.DTOs.Article.Response;
using BlogApp.Domain.Entities;

namespace BlogApp.Application.Abstractions.Services
{
    public interface IArticleService
    {
        public Task<bool> CreateArticleAsync(CreateArticleDTO model);
        public Task<bool> RemoveArticleAsync(string id);
        public Task<bool> UpdateArticleAsync(string id, Article article);
        public Task<Article> GetArticleByID(string id);
        public List<Article> GetAll();
        public Task<List<GetUserArticlesResponse>> GetUserArticles(GetUserArticlesDTO model);
    }
}
