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

    public async Task<Menu> AddMenu(Menu menu)
    {
        await _dbContext.Menus.AddAsync(menu);

        _dbContext.SaveChanges();

        return menu;
    }

    public async Task DeleteMenu(int id)
    {
        var menu = _dbContext.Menus.Find(id);

        await _dbContext.Menus.AddAsync(menu);

        _dbContext.SaveChanges();
    }

    public async Task<List<Menu>> GetAllMenu()
    {
        return await _dbContext.Menus.ToListAsync();
    }

    public async Task<Menu> GetMenuById(int id)
    {
        return await _dbContext.Menus.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Menu> UpdateMenu(int id, Menu menu)
    {
        var menuResult = await _dbContext.Menus.FindAsync(id);

        menuResult.Name = menu.Name;
        menuResult.Description = menu.Description;
        menuResult.Price = menu.Price;

        _dbContext.SaveChanges();

        return menu;
    }
}
