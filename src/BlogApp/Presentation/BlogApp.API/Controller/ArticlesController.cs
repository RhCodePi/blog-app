using BlogApp.Application.Abstractions.Services;
using BlogApp.Application.DTOs.Article;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "User")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IValidator<EditArticleDTO> _editArticleValidator;

        public ArticlesController(IArticleService articleService, IValidator<EditArticleDTO> validator)
        {
            _articleService = articleService;
            _editArticleValidator = validator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateArticle(CreateArticleDTO model)
        {
            var result = await _articleService.CreateArticleAsync(model);

            return Ok(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _articleService.GetAll();

            return Ok(result.Select(p => new
            {
                Id = p.Id.ToString(),
                p.Title,
                p.Content,
            }));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetUserArticles(GetUserArticlesDTO model)
        {
            var result = await _articleService.GetUserArticlesAsync(model);

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> EditArticle(EditArticleDTO model)
        {
            var validResult = _editArticleValidator.Validate(model);

            if(!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }


            var result = await _articleService.EditArticleAsync(model);


            return Ok(result);
        }
    }
}
