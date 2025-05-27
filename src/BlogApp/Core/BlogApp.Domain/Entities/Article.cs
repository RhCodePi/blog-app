using BlogApp.Domain.Entities.Common;
using BlogApp.Domain.Entities.Identity;

namespace BlogApp.Domain.Entities
{
    public class Article: BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public string UserID { get; set; }
        public AppUser User { get; set; }
    }
}
