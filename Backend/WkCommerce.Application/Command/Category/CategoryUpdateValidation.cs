using FluentValidation;

namespace WkCommerce.Application.Command.Category;

public class CategoryUpdateValidation : AbstractValidator<CategoryUpdateCommand>
{
    public CategoryUpdateValidation()
    {
        RuleFor(a => a.Name)
            .NotNull()
            .MinimumLength(3)
            .WithMessage("O Nome da Categoria deve ser Informado");
        
        RuleFor(a => a.Description)
            .NotNull()
            .MinimumLength(3)
            .WithMessage("A Descrição da Categoria deve ser Informada");
    }
}