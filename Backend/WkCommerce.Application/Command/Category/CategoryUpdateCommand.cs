using WkCommerce.Core.Handlers.Interfaces;

namespace WkCommerce.Application.Command.Category;

public class CategoryUpdateCommand : ICommand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}