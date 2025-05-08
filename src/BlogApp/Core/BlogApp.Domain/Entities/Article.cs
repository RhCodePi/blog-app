using BlogApp.Domain.Entities.Common;

namespace BlogApp.Domain.Entities
{
    public class Article: BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
