using Microsoft.EntityFrameworkCore;
using WkCommerce.Domain.Entity;
using WkCommerce.Infrastucture.Contract;

namespace WkCommerce.Infrastucture.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task<int> Create(Product product)
    {
        _dbContext.Product.Add(product);
        await _dbContext.SaveChangesAsync();
        return product.Id;
    }

    public async Task<Product> Get(int id)
    {
        return await _dbContext.Product.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task Delete(int id)
    {
        var product = _dbContext.Product.Find(id);
        
        if(product == null) return;
        
        _dbContext.Product.Remove(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        _dbContext.Product.Update(product);
        await _dbContext.SaveChangesAsync();
    }
}