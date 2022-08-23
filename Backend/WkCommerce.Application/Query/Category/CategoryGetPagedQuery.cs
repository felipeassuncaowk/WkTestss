using WkCommerce.Core.Handlers;

namespace WkCommerce.Application.Query.Category;

public class CategoryGetPagedQuery : PagedQuery<Domain.Entity.Category>
{
    public string Name { get; set; }

    public CategoryGetPagedQuery() { }

    public CategoryGetPagedQuery(string name, int index, int size) : base(index, size)
    {
        Name = name;
    }
}