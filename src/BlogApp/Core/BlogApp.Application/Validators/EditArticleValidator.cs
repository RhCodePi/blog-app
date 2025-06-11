using BlogApp.Application.DTOs.Article;
using FluentValidation;

namespace BlogApp.Application.Validators
{
    public class EditArticleValidator : AbstractValidator<EditArticleDTO>
    {
        public EditArticleValidator()
        {
            RuleFor(x => x.ArticleId)
                .NotEmpty().WithMessage("article id cannot be null");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("title cannot be null");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("content cannot be null"); 
        }
    }
}
