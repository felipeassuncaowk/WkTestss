using WkCommerce.Core.Handlers.Interfaces;

namespace WkCommerce.Application.Command.Category;

public class CategoryDeleteCommand : ICommand
{
    public int Id { get; set; }

    public CategoryDeleteCommand(int id)
    {
        Id = id;
    }
}