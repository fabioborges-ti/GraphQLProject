using GraphQL.Types;

namespace GraphQLProject.Mutation
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation(IServiceProvider serviceProvider)
        {
            Field<MenuMutation>("MenuMutation")
                .Resolve(context => serviceProvider.GetRequiredService<MenuMutation>());

            Field<CategoryMutation>("CategoryMutation")
                .Resolve(context => serviceProvider.GetRequiredService<CategoryMutation>());

            Field<ReservationMutation>("ReservationMutation")
                .Resolve(context => serviceProvider.GetRequiredService<ReservationMutation>());
        }
    }
}