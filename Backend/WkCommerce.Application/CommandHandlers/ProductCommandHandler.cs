using MediatR;
using WkCommerce.Application.Command.Product;
using WkCommerce.Core.Handlers;
using WkCommerce.Core.Handlers.Interfaces;
using WkCommerce.Domain.Entity;
using WkCommerce.Infrastucture.Contract;

namespace WkCommerce.Application.CommandHandlers;

public class ProductCommandHandler : 
    ICommandHandler<ProductCreateCommand, int>,
    ICommandHandler<ProductDeleteCommand>,
    ICommandHandler<ProductUpdateCommand>
{
    private readonly IProductRepository _productRepository;

    
    public ProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<int>> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        var id = await _productRepository.Create(new Product
        {
            Description = request.Description,
            Name = request.Name,
            FgActive = request.FgActive,
            IdCategory = request.IdCategory
        });

        return await Result.SuccessAsync(id);
    }

    public async Task<Result<Unit>> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
    {
       await _productRepository.Delete(request.Id);
       return await Result.SuccessAsync();
    }

    public async Task<Result<Unit>> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var product = new Product() { Id = request.Id, Name = request.Name, Description = request.Description, FgActive = request.FgActive};
        await _productRepository.Update(product);
        return await Result.SuccessAsync();
    }
}