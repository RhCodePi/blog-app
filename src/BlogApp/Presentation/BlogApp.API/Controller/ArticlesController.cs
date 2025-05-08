using BlogApp.Application.Abstractions.Services;
using BlogApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            var result = await _articleService.CreateArticle(article);

            return Ok(result);
        }

        [HttpGet("getAll")]
        public  IActionResult GetAll()
        {
            var result = _articleService.GetAll();

            return Ok(result);
        }
    }
}
