using FluentValidation;

namespace WkCommerce.Application.Command.Product;

public class ProductCreateValidation : AbstractValidator<ProductCreateCommand>
{
    public ProductCreateValidation()
    {
        RuleFor(a => a.Name)
            .NotNull()
            .MinimumLength(3)
            .WithMessage("O Nome do Produto deve ser Informado");
        
        RuleFor(a => a.Description)
            .NotNull()
            .MinimumLength(3)
            .WithMessage("A Descrição do Produto deve ser Informada");
    }
}

public class ProductUpdateValidation : AbstractValidator<ProductUpdateCommand>
{
    public ProductUpdateValidation()
    {
        RuleFor(a => a.Name)
            .NotNull()
            .MinimumLength(3)
            .WithMessage("O Nome do Produto deve ser Informado");
        
        RuleFor(a => a.Description)
            .NotNull()
            .MinimumLength(3)
            .WithMessage("A Descrição do Produto deve ser Informada");
    }
}