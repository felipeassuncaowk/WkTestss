using WkCommerce.Core.Handlers.Interfaces;

namespace WkCommerce.Application.Command.Product;

public class ProductCreateCommand : ICommand<int>
{
    public int IdCategory { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool FgActive { get; set; }
}