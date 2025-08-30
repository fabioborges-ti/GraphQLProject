using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type.Category;

namespace GraphQLProject.Query;

public class CategoryQuery : ObjectGraphType
{
    public CategoryQuery(ICategoryRepository categoryRepository)
    {
        Field<ListGraphType<CategoryType>>(Name = "Categories").ResolveAsync(async context =>
        {
            return await categoryRepository.GetCategories();
        });
    }
}
