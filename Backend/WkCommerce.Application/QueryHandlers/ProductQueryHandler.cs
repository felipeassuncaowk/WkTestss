using Microsoft.EntityFrameworkCore;
using WkCommerce.Application.Query.Product;
using WkCommerce.Core.Handlers;
using WkCommerce.Core.Handlers.Interfaces;
using WkCommerce.Domain.Entity;
using WkCommerce.Infrastucture;
using WkCommerce.Infrastucture.Contract;

namespace WkCommerce.Application.QueryHandlers;

public class ProductQueryHandler : 
    IQueryHandler<ProductGetByIdQuery, Product>,
    IPagedQueryHandler<ProductGetPagedQuery, Product>
{
    private readonly AppDbContext _dbContext;
    private readonly IProductRepository _productRepository;

    public ProductQueryHandler(AppDbContext dbContext, IProductRepository productRepository)
    {
        _dbContext = dbContext;
        _productRepository = productRepository;
    }

    public async Task<Result<Product>> Handle(ProductGetByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.Get(request.Id);
        return await Result.SuccessAsync(product);
    }

    public async Task<Result<PagedResult<Product>>> Handle(ProductGetPagedQuery request, CancellationToken cancellationToken)
    {
        var products = _dbContext.Product.Where(x =>
            string.IsNullOrEmpty(request.Name) || x.Name.Contains(request.Name)
        );
        var offset = request.PageSettings.GetOffset();
        var size = request.PageSettings.Size;
        var items = await products.Skip(offset).Take(size).ToListAsync(cancellationToken: cancellationToken);
        return PagedResult<Product>.Success(items, request.PageSettings.Current(products.Count()));
    }
}