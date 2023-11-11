using Hall.Domain;
using Hall.Domain.Models.Categories;

namespace Hall.Infrastructure.Persistence.Sql;

public class UnitOfWork:IUnitOfWork
{
    private readonly DataBaseContext _dbContext;
    public ICategoryRepository CategoryRepository { get; }
    public UnitOfWork(ICategoryRepository categoryRepository, DataBaseContext dbContext)
    {
        CategoryRepository = categoryRepository;
        _dbContext = dbContext;
    }
    public async Task<int> CommitAsync() => await _dbContext.SaveChangesAsync();
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }

}