using GraphQL.Types;

namespace GraphQLProject.Type.Menu;

public class MenuInputType : InputObjectGraphType
{
    public MenuInputType()
    {
        Name = "MenuInput";
        Description = "Input type for creating or updating a menu item";

        Field<NonNullGraphType<StringGraphType>>("name").Description("Name of the menu item");
        Field<NonNullGraphType<StringGraphType>>("description").Description("Detailed description of the menu item");
        Field<NonNullGraphType<FloatGraphType>>("price").Description("Price of the menu item");
        Field<StringGraphType>("imageUrl").Description("URL of the menu item's image");
        Field<NonNullGraphType<IntGraphType>>("categoryId");
    }
}