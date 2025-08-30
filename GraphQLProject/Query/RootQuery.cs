using GraphQL.Types;

namespace GraphQLProject.Query;

public class RootQuery : ObjectGraphType
{
    public RootQuery()
    {
        Field<MenuQuery>(Name = "MenuQuery").Resolve(context => new { });
        Field<CategoryQuery>(Name = "CategoryQuery").Resolve(context => new { });
        Field<ReservationQuery>(Name = "ReservationQuery").Resolve(context => new { });
    }
}
