using Hall.Domain.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace Hall.Infrastructure.Persistence.Sql.Repositories;

public class CategoryRepository:ICategoryRepository
{
    private readonly DataBaseContext _dbContext;
    public CategoryRepository(DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(Category category) => await _dbContext.AddAsync(category);

    public async Task<List<Category>> All()
        => await _dbContext.Categories.AsNoTracking().ToListAsync();
}