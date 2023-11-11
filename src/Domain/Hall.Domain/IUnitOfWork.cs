using Hall.Domain.Models.Categories;

namespace Hall.Domain;

public interface IUnitOfWork:IDisposable
{
    ICategoryRepository CategoryRepository { get; }
    Task<int> CommitAsync();

}