using GraphQLProject.Models;

namespace GraphQLProject.Interfaces;

public interface IMenuRepository
{
    Task<List<MenuModel>> GetAllMenu();
    Task<MenuModel> GetMenuById(int id);
    Task<MenuModel> AddMenu(MenuModel menu);
    Task<MenuModel> UpdateMenu(int id, MenuModel menu);
    Task DeleteMenu(int id);
}
