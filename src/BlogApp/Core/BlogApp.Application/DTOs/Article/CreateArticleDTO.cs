namespace BlogApp.Application.DTOs.Article
{
    public class CreateArticleDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string RefreshToken { get; set; }
    }
}
