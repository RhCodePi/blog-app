using BlogApp.Application.Abstractions.Repositories;
using BlogApp.Application.Abstractions.Repositories.Articles;
using BlogApp.Application.Abstractions.Services;
using BlogApp.Domain.Entities;

namespace BlogApp.Persistance.Concretes.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleReadRepository _articleReadRepository;
        private readonly IArticleWriteRepository _articleWriteRepository;

        public ArticleService(IArticleReadRepository articleReadRepository, IArticleWriteRepository articleWriteRepository)
        {
            _articleReadRepository = articleReadRepository;
            _articleWriteRepository = articleWriteRepository;
        }

        public async Task<bool> CreateArticleAsync(Article article)
        {
            var result = await _articleWriteRepository.AddAsync(article);

            await _articleWriteRepository.SaveAsync();

            return result;
        }

        public async Task<bool> RemoveArticleAsync(string id)
        {

            var result  = await _articleWriteRepository.RemoveAsync(id);

            await _articleWriteRepository.SaveAsync();

            return result;
        }

        public async Task<Article> GetArticleByID(string id)
        {
            var result = await _articleReadRepository.GetByIdAsync(id);

            return result;
        }

        public async Task<bool> UpdateArticleAsync(string id, Article article)
        {

            var articleOld = await _articleReadRepository.GetByIdAsync(id);

            articleOld.Title = article.Title;
            articleOld.UpdateDate = DateTime.UtcNow;
            articleOld.Content = article.Content;

            var result = _articleWriteRepository.Update(articleOld);
            await _articleWriteRepository.SaveAsync();

            return result;
        }

        public List<Article> GetAll()
        {
            return _articleReadRepository.GetAll().ToList();
        }
    }
}
