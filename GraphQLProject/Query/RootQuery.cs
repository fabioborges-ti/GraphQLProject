using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type.Category;
using GraphQLProject.Type.Menu;
using GraphQLProject.Type.Reservation;

public class RootQuery : ObjectGraphType
{
    public RootQuery(IMenuRepository menuRepository, ICategoryRepository categoryRepository, IReservationRepository reservationRepository)
    {
        Field<ListGraphType<MenuType>>("menus")
            .ResolveAsync(async context => await menuRepository.GetAllMenu());

        Field<ListGraphType<CategoryType>>("categories")
            .ResolveAsync(async context => await categoryRepository.GetCategories());

        Field<ListGraphType<ReservationType>>("reservations")
            .ResolveAsync(async context => await reservationRepository.GetReservations());
    }
}