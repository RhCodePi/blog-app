using BlogApp.Domain.Entities;

namespace BlogApp.Application.Abstractions.Repositories
{
    public interface IArticleRepository
    {
        public bool CreateArticle(Article article);
        public void DeleteArticle(string id);
        public void UpdateArticle(string id, Article updatedArticle);
        public Article GetArticleById(string id);
        public List<Article> GetAll();
    }
}
