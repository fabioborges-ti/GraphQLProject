using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type.Reservation;

namespace GraphQLProject.Query;

public class ReservationQuery : ObjectGraphType
{
    public ReservationQuery(IReservationRepository reservationRepository)
    {
        Field<ListGraphType<ReservationType>>(Name = "Reservations").ResolveAsync(async context =>
        {
            return await reservationRepository.GetReservations();
        });
    }
}
