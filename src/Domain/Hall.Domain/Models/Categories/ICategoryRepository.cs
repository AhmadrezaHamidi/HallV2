namespace Hall.Domain.Models.Categories;

public interface ICategoryRepository
{
    Task Add(Category category);
    Task<List<Category>> All();
}