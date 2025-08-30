using GraphQL.Types;

namespace GraphQLProject.Type.Menu;

public class MenuInputType : InputObjectGraphType
{
    public MenuInputType()
    {
        Name = "MenuInput";
        Description = "Input type for creating or updating a menu item";

        Field<string>("name").Description("Name of the menu item");
        Field<string>("description").Description("Detailed description of the menu item");
        Field<float>("price").Description("Price of the menu item");
        Field<string>("imageUrl", nullable: true).Description("URL of the menu item's image");
    }
}