﻿using GraphQLProject.Models;

namespace GraphQLProject.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategories();
    Task<Category> AddCategory(Category category);
    Task<Category> UpdateCategory(int id, Category category);
    Task DeleteCategory(int id);
}
