using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly GraphQLDbContext _dbContext;

    public MenuRepository(GraphQLDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MenuModel> AddMenu(MenuModel menu)
    {
        await _dbContext.Menus.AddAsync(menu);

        _dbContext.SaveChanges();

        return menu;
    }

    public async Task DeleteMenu(int id)
    {
        var menu = await _dbContext.Menus.FindAsync(id);
        if (menu != null)
        {
            _dbContext.Menus.Remove(menu);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<MenuModel>> GetAllMenu()
    {
        return await _dbContext.Menus.ToListAsync();
    }

    public async Task<MenuModel> GetMenuById(int id)
    {
        return await _dbContext.Menus.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<MenuModel> UpdateMenu(int id, MenuModel menu)
    {
        var menuResult = await _dbContext.Menus.FindAsync(id);

        menuResult.Name = menu.Name;
        menuResult.Description = menu.Description;
        menuResult.Price = menu.Price;

        _dbContext.SaveChanges();

        return menu;
    }
}
