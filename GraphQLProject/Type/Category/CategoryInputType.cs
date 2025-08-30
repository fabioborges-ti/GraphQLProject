using GraphQL.Types;

namespace GraphQLProject.Type.Category;

public class CategoryInputType : InputObjectGraphType
{
    public CategoryInputType()
    {
        Name = "CategoryInput";
        Description = "Input type for creating or updating a category";

        Field<string>("name").Description("Name of the category");
        Field<string>("imageUrl", nullable: true).Description("URL of the image representing the category");
    }
}