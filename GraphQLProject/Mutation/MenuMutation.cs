using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation;

public class MenuMutation : ObjectGraphType
{
    public MenuMutation(IMenuRepository menuRepository)
    {
        Field<MenuType>("CreateMenu")
            .Arguments(new QueryArgument<MenuInputType> { Name = "menu" })
            .ResolveAsync(async context =>
            {
                return await menuRepository.AddMenu(context.GetArgument<Menu>("menu"));
            });

        Field<MenuType>("UpdateMenu")
            .Arguments(new QueryArgument<IntGraphType> { Name = "menuId" }, new QueryArgument<MenuInputType> { Name = "menu" })
            .ResolveAsync(async context =>
            {
                var menuId = context.GetArgument<int>("menuId");
                var menu = context.GetArgument<Menu>("menu");

                return await menuRepository.UpdateMenu(menuId, menu);
            });

        Field<StringGraphType>("DeleteMenu")
            .Arguments(new QueryArgument<IntGraphType> { Name = "menuId" })
            .ResolveAsync(async context =>
            {
                var menuId = context.GetArgument<int>("menuId");

                await menuRepository.DeleteMenu(menuId);

                return $"The menu with id {menuId} has been deleted.";
            });
    }
}
