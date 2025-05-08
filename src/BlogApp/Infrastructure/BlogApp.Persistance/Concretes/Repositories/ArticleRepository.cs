using BlogApp.Application.Abstractions.Repositories;
using BlogApp.Domain.Entities;

namespace BlogApp.Persistance.Concretes.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly List<Article> articles; 

        public ArticleRepository() {
            if(articles == null)
                articles = new List<Article>();
        }

        public bool CreateArticle(Article article)
        {
            articles.Add(article);

            return true;
        }

        public void DeleteArticle(string id)
        {
            foreach (var item in articles)
            {
                if(item.Id.ToString() == id)
                {
                    articles.Remove(item);
                }
            }
        }

        public List<Article> GetAll()
        {
            if (articles.Count == 0)
                throw new Exception("Article is emtpy");

            return articles;
        }

        public Article GetArticleById(string id)
        {
            return articles.FirstOrDefault(article =>  article.Id.ToString() == id);
        }

        public void UpdateArticle(string id, Article updatedArticle)
        {
            var article = articles.FirstOrDefault(article=>article.Id.ToString() == id);

            if(article != null)
            {
                article.Title = updatedArticle.Title;
                article.UpdateDate = DateTime.Now;
                article.Content = updatedArticle.Content;
            }
        }
    }
}
