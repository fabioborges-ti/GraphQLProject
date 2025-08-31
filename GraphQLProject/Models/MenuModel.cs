namespace GraphQLProject.Models;

public class MenuModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }

    // MER
    public int CategoryId { get; set; }
    public CategoryModel CategoryNavigation { get; set; }
}
