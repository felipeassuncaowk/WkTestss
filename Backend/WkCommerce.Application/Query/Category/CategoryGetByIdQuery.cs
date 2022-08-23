using WkCommerce.Core.Handlers.Interfaces;

namespace WkCommerce.Application.Query.Category;

public class CategoryGetByIdQuery : IQuery<Domain.Entity.Category>
{
    public int Id { get; }

    public CategoryGetByIdQuery(int id)
    {
        this.Id = id;
    }
}