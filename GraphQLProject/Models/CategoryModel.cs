namespace GraphQLProject.Models;

public class CategoryModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }

    // POO
    public ICollection<MenuModel> Menus { get; set; }
}
