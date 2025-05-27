using BlogApp.Application.Abstractions.Services;
using BlogApp.Application.DTOs.Article;
using BlogApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "User")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserArticles([FromForm] GetUserArticlesDTO model)
        {
            var result = await _articleService.GetUserArticles(model);

            return Ok(result);
        }
    }
}
