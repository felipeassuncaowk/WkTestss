using WkCommerce.Domain.Entity;

namespace WkCommerce.Infrastucture.Contract;

public interface ICategoryRepository
{
    public Task<int> Create(Category category);
    public Task<Category> Get(int id);
    public Task Delete(int id);
    public Task Update(Category category);
}