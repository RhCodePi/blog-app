using BlogApp.Application.Abstractions.Repositories;
using BlogApp.Application.Abstractions.Services;
using BlogApp.Domain.Entities;

namespace BlogApp.Persistance.Concretes.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }


        public async Task<bool> CreateArticle(Article article)
        {
            return _articleRepository.CreateArticle(article);
        }

        public async Task DeleteArticle(string id)
        {
            _articleRepository.DeleteArticle(id);
        }

        public async Task<Article> GetArticleByID(string id)
        {
            return _articleRepository.GetArticleById(id);
        }

        public async Task UpdateArticle(string id, Article article)
        {
            _articleRepository.UpdateArticle(id, article);
        }

        public List<Article> GetAll()
        {
            return _articleRepository.GetAll();
        }
    }
}
