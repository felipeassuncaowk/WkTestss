using WkCommerce.Core.Handlers.Interfaces;

namespace WkCommerce.Application.Command.Product;

public class ProductDeleteCommand : ICommand
{
    public int Id { get; set; }
    
    public ProductDeleteCommand(int id)
    {
        Id = id;
    }
}