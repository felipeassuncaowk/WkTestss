using Microsoft.EntityFrameworkCore;
using WkCommerce.Domain.Entity;
using WkCommerce.Infrastucture.Contract;

namespace WkCommerce.Infrastucture.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;

    public CategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Create(Category category)
    {
        _dbContext.Category.Add(category);
        await _dbContext.SaveChangesAsync();
        return category.Id;
    }

    public async Task<Category> Get(int id)
    {
        return await _dbContext.Category.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task Delete(int id)
    {
        var category = await _dbContext.Category.FindAsync(id);
        
        if(category == null) return;
        
        _dbContext.Category.Remove(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Category category)
    {
        _dbContext.Category.Update(category);
        await _dbContext.SaveChangesAsync();
    }
}