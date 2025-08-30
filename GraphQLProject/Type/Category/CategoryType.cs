using GraphQL.Types;
using GraphQLProject.Models;

namespace GraphQLProject.Type.Category;

public class CategoryType : ObjectGraphType<CategoryModel>
{
    public CategoryType()
    {
        Field(x => x.Id).Description("Unique identifier for the category.");
        Field(x => x.Name).Description("Name of the category.");
        Field(x => x.ImageUrl).Description("URL of the image representing the category.");
        Field<ListGraphType<MenuType>>("menus")
            .Description("List of menu items that belong to this category.")
            .Resolve(context => context.Source.Menus);
    }
}
