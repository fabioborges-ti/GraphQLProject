using GraphQL.Types;

namespace GraphQLProject.Type.Reservation;

public class ReservationInputType : InputObjectGraphType
{
    public ReservationInputType()
    {
        Name = "ReservationInput";
        Field<StringGraphType>("customerName");
        Field<StringGraphType>("email");
        Field<StringGraphType>("phoneNumber");
        Field<IntGraphType>("partySize");
        Field<StringGraphType>("specialRequest");
        Field<DateTimeGraphType>("reservationDate");
    }
}