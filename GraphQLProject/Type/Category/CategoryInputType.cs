using GraphQL.Types;

namespace GraphQLProject.Type.Category;

public class CategoryInputType : InputObjectGraphType
{
    public CategoryInputType()
    {
        Name = "CategoryInput";
        Field<StringGraphType>("name");
        Field<StringGraphType>("imageUrl");
    }
}