using WkCommerce.Core.Handlers.Interfaces;

namespace WkCommerce.Application.Command.Category;

public class CategoryCreateCommand : ICommand<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}