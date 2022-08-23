using MediatR;
using WkCommerce.Application.Command.Category;
using WkCommerce.Core.Handlers;
using WkCommerce.Core.Handlers.Interfaces;
using WkCommerce.Domain.Entity;
using WkCommerce.Infrastucture.Contract;

namespace WkCommerce.Application.CommandHandlers;

public class CategoryCommandHandler : 
    ICommandHandler<CategoryCreateCommand, int>,
    ICommandHandler<CategoryDeleteCommand>,
    ICommandHandler<CategoryUpdateCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    
    public CategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<int>> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        var id = await _categoryRepository.Create(new Category
        {
            Name = request.Name,
            Description = request.Description
        });
        return await Result.SuccessAsync(id);
    }

    public async Task<Result<Unit>> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
    {
        await _categoryRepository.Delete(request.Id);
        return await Result.SuccessAsync();
    }

    public async Task<Result<Unit>> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
    {
        var category = new Category { Id = request.Id, Name = request.Name, Description = request.Description };
        await _categoryRepository.Update(category);
        return await Result.SuccessAsync();
    }
}