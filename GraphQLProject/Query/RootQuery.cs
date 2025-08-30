using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type.Category;
using GraphQLProject.Type.Menu;
using GraphQLProject.Type.Reservation;

namespace GraphQLProject.Query;

public class RootQuery : ObjectGraphType
{
    public RootQuery(IMenuRepository menuRepository, ICategoryRepository categoryRepository, IReservationRepository reservationRepository)
    {
        Description = "The root query type for all API queries.";

        Field<ListGraphType<MenuType>>("menus")
            .ResolveAsync(async context => await menuRepository.GetAllMenu());

        Field<ListGraphType<CategoryType>>("categories")
            .ResolveAsync(async context => await categoryRepository.GetCategories());

        Field<ListGraphType<ReservationType>>("reservations")
            .ResolveAsync(async context => await reservationRepository.GetReservations());
    }
}