using WkCommerce.Core.Handlers.Interfaces;

namespace WkCommerce.Application.Query.Product;

public class ProductGetByIdQuery : IQuery<Domain.Entity.Product>
{
    public int Id { get; }

    public ProductGetByIdQuery(int id)
    {
        this.Id = id;
    }
}