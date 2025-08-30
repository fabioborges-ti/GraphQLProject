using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation;

public class ReservationMutation : ObjectGraphType
{
    public ReservationMutation(IReservationRepository reservationRepository)
    {
        Field<ReservationType>("createReservation")
            .Arguments(new QueryArgument<ReservationInputType> { Name = "reservation" })
            .ResolveAsync(async context =>
            {
                var reservation = context.GetArgument<Reservation>("reservation");
                return await reservationRepository.AddReservaReservation(reservation);
            });
    }
}