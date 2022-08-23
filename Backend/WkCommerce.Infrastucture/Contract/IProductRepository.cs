using WkCommerce.Domain.Entity;

namespace WkCommerce.Infrastucture.Contract;

public interface IProductRepository
{
    public Task<int> Create(Product product);
    public Task<Product> Get(int id);
    public Task Delete(int id);
    public Task Update(Product product);
}