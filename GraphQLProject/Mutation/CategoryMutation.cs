using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type.Category;

namespace GraphQLProject.Mutation;

public class CategoryMutation : ObjectGraphType
{
    public CategoryMutation(ICategoryRepository categoryRepository)
    {
        Field<CategoryType>("CreateCategory")
            .Arguments(new QueryArgument<CategoryInputType> { Name = "category" })
            .ResolveAsync(async context =>
            {
                var category = context.GetArgument<CategoryModel>("category");
                return await categoryRepository.AddCategory(category);
            });

        Field<CategoryType>("UpdateCategory")
            .Arguments(new QueryArgument<IntGraphType> { Name = "id" }, new QueryArgument<CategoryInputType> { Name = "category" })
            .ResolveAsync(async context =>
            {
                var id = context.GetArgument<int>("id");
                var category = context.GetArgument<CategoryModel>("category");

                return await categoryRepository.UpdateCategory(id, category);
            });

        Field<StringGraphType>("DeleteCategory")
            .Arguments(new QueryArgument<IntGraphType> { Name = "id" })
            .ResolveAsync(async context =>
            {
                var id = context.GetArgument<int>("id");
                await categoryRepository.DeleteCategory(id);
                return $"A categoria com o id {id} foi deletada.";
            });
    }
}