using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query;

public class MenuQuery : ObjectGraphType
{
    public MenuQuery(IMenuRepository menuRepository)
    {
        Field<ListGraphType<MenuType>>(Name = "Menus").ResolveAsync(async context => await menuRepository.GetAllMenu());

        Field<MenuType>(Name = "Menu")
            .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }))
            .ResolveAsync(async context =>
            {
                return await menuRepository.GetMenuById(context.GetArgument<int>("menuId"));
            });
    }
}
