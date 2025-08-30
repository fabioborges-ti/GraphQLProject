using GraphQLProject.Models;

namespace GraphQLProject.Interfaces;

public interface ICategoryRepository
{
    Task<List<CategoryModel>> GetCategories();
    Task<CategoryModel> AddCategory(CategoryModel category);
    Task<CategoryModel> UpdateCategory(int id, CategoryModel category);
    Task DeleteCategory(int id);
}
