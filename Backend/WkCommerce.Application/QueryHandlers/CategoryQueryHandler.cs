using Microsoft.EntityFrameworkCore;
using WkCommerce.Application.Query.Category;
using WkCommerce.Core.Handlers;
using WkCommerce.Core.Handlers.Interfaces;
using WkCommerce.Domain.Entity;
using WkCommerce.Infrastucture;
using WkCommerce.Infrastucture.Contract;

namespace WkCommerce.Application.QueryHandlers;

public class CategoryQueryHandler : 
    IQueryHandler<CategoryGetByIdQuery, Category>,
    IPagedQueryHandler<CategoryGetPagedQuery, Category>
{
    private readonly AppDbContext _dbContext;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryQueryHandler(AppDbContext dbContext, ICategoryRepository categoryRepository)
    {
        _dbContext = dbContext;
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<Category>> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.Get(request.Id);
        return await Result.SuccessAsync(category);
    }

    public async Task<Result<PagedResult<Category>>> Handle(CategoryGetPagedQuery request, CancellationToken cancellationToken)
    {
        var categories = _dbContext.Category.Where(x =>
            string.IsNullOrEmpty(request.Name) || x.Name.Contains(request.Name)
        );
        var offset = request.PageSettings.GetOffset();
        var size = request.PageSettings.Size;
        var items = await categories.Skip(offset).Take(size).ToListAsync(cancellationToken: cancellationToken);
        return PagedResult<Category>.Success(items, request.PageSettings.Current(categories.Count()));
    }
}