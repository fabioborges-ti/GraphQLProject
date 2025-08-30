namespace GraphQLProject.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }

    // POO
    public ICollection<Menu> Menus { get; set; }
}
