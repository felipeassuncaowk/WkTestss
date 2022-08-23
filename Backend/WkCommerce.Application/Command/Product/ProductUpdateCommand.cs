using WkCommerce.Core.Handlers.Interfaces;

namespace WkCommerce.Application.Command.Product;

public class ProductUpdateCommand : ICommand
{
    public int Id { get; set; }
    public int IdCategory { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool FgActive { get; set; }
}