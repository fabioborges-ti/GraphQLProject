using GraphQL.Types;

namespace GraphQLProject.Type;

public class CategoryInputType : InputObjectGraphType
{
    public CategoryInputType()
    {
        Name = "CategoryInput";
        Field<StringGraphType>("name");
        Field<StringGraphType>("imageUrl");
    }
}