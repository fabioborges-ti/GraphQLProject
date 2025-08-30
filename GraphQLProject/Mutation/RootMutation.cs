using GraphQL.Types;

namespace GraphQLProject.Mutation
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<MenuMutation>("MenuMutation").Resolve(context => new { });
        }
    }
}