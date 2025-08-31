using GraphQL.Types;

namespace GraphQLProject.Type.Category;

public class CategoryInputType : InputObjectGraphType
{
    public CategoryInputType()
    {
        Name = "CategoryInput";
        Description = "Input type for creating or updating a category";

        Field<NonNullGraphType<IntGraphType>>("id");
        Field<NonNullGraphType<StringGraphType>>("name").Description("Name of the category");
        Field<StringGraphType>("imageUrl").Description("URL of the image representing the category");
    }
}