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


        public List<Article> GetAll()
        {
            return [.. _articleReadRepository.GetAll()];
        }


        public async Task<List<GetUserArticlesResponse>> GetUserArticlesAsync(GetUserArticlesDTO model)
        {
            var user = await _userService.GetUserWithRefreshToken(model.RefreshToken);

            if (user == null) throw new UserNotFoundException();

            var result = _articleReadRepository.GetWhere(x => x.UserID == user.Id).Select(x => new GetUserArticlesResponse
            {
                Id = x.Id.ToString(),
                Title = x.Title,
                Content = x.Content,
                CreatedDate = _dateFormatter.ConvertToString(x.CreateDate),
                UpdatedDate = (x.UpdateDate != null ? _dateFormatter.ConvertToString(x.UpdateDate.Value) : UNCHANGED),
            }).ToList();

            if (result.Count == 0) return [];

            return result;
        }

        public async Task<EditArticleResponse> EditArticleAsync(EditArticleDTO model)
        {
            var article = await _articleReadRepository.GetByIdAsync(model.ArticleId);

            if (article == null) throw new Exception();// I thought this artilce is not null here

            var isTitleMatch = String.Equals(article.Title, model.Title, StringComparison.OrdinalIgnoreCase);
            var isContentMatch = String.Equals(article.Content, model.Content, StringComparison.OrdinalIgnoreCase); 


            article.Content = isContentMatch ? article.Content : model.Content;
            article.Title = isTitleMatch ? article.Title : model.Title;

            if(isTitleMatch || isContentMatch)
            {
                if (!isTitleMatch)
                {
                    article.UpdateDate = DateTime.UtcNow;
                    
                    await _articleWriteRepository.SaveAsync();

                    return new EditArticleResponse
                    {
                        Message = "title updated!",
                        Success = true,
                    };
                }

                if(!isContentMatch)
                {
                    article.UpdateDate = DateTime.UtcNow;

                    await _articleWriteRepository.SaveAsync();


                    return new EditArticleResponse
                    {
                        Message = "content updated!",
                        Success = true,
                    };
                }

                return new EditArticleResponse
                {
                    Message = "content or title must be diffrent old one",
                    Success = false,
                };
            }
            else
            {
                article.UpdateDate = DateTime.UtcNow;

                await _articleWriteRepository.SaveAsync();

                return new EditArticleResponse
                {
                    Message = "article updated!",
                    Success = true,
                };
            }

        }

        public async Task<DeleteArticleResponse> DeleteArticleAsync(DeleteArticleDTO model)
        {
            var result = await _articleWriteRepository.RemoveAsync(model.ArticleId);

            if (result)
            {
                await _articleWriteRepository.SaveAsync();
                return new DeleteArticleResponse() { IsDeleted = result, Message = "article was deleted" };
            }

            return new DeleteArticleResponse() { IsDeleted = result, Message = "Something went wrong!" };
        }
    }
}
