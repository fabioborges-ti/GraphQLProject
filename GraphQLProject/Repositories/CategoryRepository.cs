using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly GraphQLDbContext _dbContext;

    public CategoryRepository(GraphQLDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CategoryModel>> GetCategories()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<CategoryModel> AddCategory(CategoryModel category)
    {
        _dbContext.Categories.Add(category);

        await _dbContext.SaveChangesAsync();

        return category;
    }

    public async Task DeleteCategory(int id)
    {
        var result = await _dbContext.Categories.FindAsync(id);

        _dbContext?.Categories.Remove(result);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<CategoryModel> UpdateCategory(int id, CategoryModel category)
    {
        var result = await _dbContext.Categories.FindAsync(id);

        result.Name = category.Name;
        result.ImageUrl = category.ImageUrl;

        await _dbContext.SaveChangesAsync();

        return result;
    }
}
