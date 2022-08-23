using WkCommerce.Core.Handlers;

namespace WkCommerce.Application.Query.Product;

public class ProductGetPagedQuery : PagedQuery<Domain.Entity.Product>
{
    public string Name { get; }
    public bool? FgActive { get; }

    public ProductGetPagedQuery(string name, bool? fgActive, int index, int size) : base(index, size)
    {
        Name = name;
        FgActive = fgActive;
    }
}