using GraphQL.Types;

namespace GraphQLProject.Type.Reservation;

public class ReservationInputType : InputObjectGraphType
{
    public ReservationInputType()
    {
        Name = "ReservationInput";
        Description = "Input type for creating or updating a reservation";

        Field<NonNullGraphType<IntGraphType>>("id");
        Field<NonNullGraphType<StringGraphType>>("customerName").Description("Name of the customer making the reservation");
        Field<NonNullGraphType<StringGraphType>>("email").Description("Email address of the customer");
        Field<NonNullGraphType<StringGraphType>>("phoneNumber").Description("Phone number of the customer");
        Field<NonNullGraphType<IntGraphType>>("partySize").Description("Number of people included in the reservation");
        Field<StringGraphType>("specialRequest").Description("Any special request made by the customer");
        Field<NonNullGraphType<DateTimeGraphType>>("reservationDate").Description("Date and time of the reservation");
    }
}