using GraphQL.Types;
using GraphQLProject.Models;

namespace GraphQLProject.Type;

public class MenuType : ObjectGraphType<Menu>
{
    public MenuType()
    {
        Field(x => x.Id).Description("Unique identifier for the menu item.");
        Field(x => x.Name).Description("Name of the menu item.");
        Field(x => x.Price).Description("Price of the menu item.");
        Field(x => x.Description).Description("Detailed description of the menu item.");
        Field(x => x.ImageUrl).Description("URL of the image representing the menu item.");
        Field(x => x.CategoryId).Description("Identifier of the category to which this menu item belongs.");
    }
}
