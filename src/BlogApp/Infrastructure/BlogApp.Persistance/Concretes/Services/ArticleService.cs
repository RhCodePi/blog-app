using BlogApp.Application.Abstractions.Repositories.Articles;
using BlogApp.Application.Abstractions.Services;
using BlogApp.Application.DTOs.Article;
using BlogApp.Application.DTOs.Article.Response;
using BlogApp.Application.Exceptions;
using BlogApp.Domain.Entities;
using BlogApp.Domain.Entities.Identity;

namespace BlogApp.Persistance.Concretes.Services
{
    public class ArticleService : IArticleService
    {
        private readonly string UNCHANGED = "Unchanged";

        private readonly IArticleReadRepository _articleReadRepository;
        private readonly IArticleWriteRepository _articleWriteRepository;
        private readonly IUserService _userService;
        private readonly IDateTimeFormatter _dateFormatter;


        public ArticleService(IArticleReadRepository articleReadRepository, IArticleWriteRepository articleWriteRepository, IUserService userService, IDateTimeFormatter dateFormatter)
        {
            _articleReadRepository = articleReadRepository;
            _articleWriteRepository = articleWriteRepository;
            _userService = userService;
            _dateFormatter = dateFormatter;
        }

        public async Task<bool> CreateArticleAsync(CreateArticleDTO model)
        {
            AppUser? user = await _userService.GetUserWithRefreshToken(model.RefreshToken);

            if (user == null) throw new UserNotFoundException("User not found");


            Article article = new()
            {
                Id = Guid.NewGuid(),
                Content = model.Content,
                Title = model.Title,
                UserID = user.Id,
                CreateDate = DateTime.UtcNow
            };

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
            return [.. _articleReadRepository.GetAll()];
        }


        public async Task<List<GetUserArticlesResponse>> GetUserArticles(GetUserArticlesDTO model)
        {
            var user = await _userService.GetUserWithRefreshToken(model.RefreshToken);

            if (user == null) throw new UserNotFoundException();

            var result = _articleReadRepository.GetWhere(x => x.UserID == user.Id).Select(x => new GetUserArticlesResponse
            {
                Id = x.Id.ToString(),
                Title = x.Title,
                CreatedDate = _dateFormatter.ConvertToString(x.CreateDate),
                UpdatedDate = (x.UpdateDate != null ? _dateFormatter.ConvertToString(x.UpdateDate.Value) : UNCHANGED),
            }).ToList();

            if (result.Count == 0) return [];

            return result;
        }
    }
}
